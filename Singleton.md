# Singleton Design Pattern - The Complete Deep Dive

## 🎯 What is Singleton Pattern?

**Singleton is a creational design pattern that ensures a class has only ONE instance throughout the application lifetime, and provides a global point of access to that instance.**

Think of it like this: In your entire .NET Core application, you want only ONE configuration manager, ONE database connection pool manager, ONE logger instance. Not 10, not 100, just ONE. That's Singleton.

---

## 🧠 The Core Problem It Solves

Imagine you're building a logging system. Without Singleton:

```csharp
// BAD - Multiple instances created
var logger1 = new Logger();
var logger2 = new Logger();
var logger3 = new Logger();
// Now you have 3 loggers writing to the same file - CHAOS!
// Race conditions, file locks, inconsistent state
```

**Problems:**

- Multiple instances waste memory
- Shared resources (files, DB connections) get corrupted
- Inconsistent state across the application
- No single source of truth

**Singleton solves this by guaranteeing ONE instance, accessed globally.**

---

## 🏗️ Implementation Patterns (6 Types You MUST Know)

### 1. **Eager Initialization (Thread-Safe by Default)**

```csharp
public sealed class Logger
{
    // Instance created at class loading time
    private static readonly Logger _instance = new Logger();
    
    // Private constructor prevents external instantiation
    private Logger()
    {
        Console.WriteLine("Logger initialized");
    }
    
    public static Logger Instance => _instance;
    
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

// Usage
Logger.Instance.Log("Application started");
```

**Pros:**

- Simple, clean code
- Thread-safe without locks (CLR guarantees static initialization is thread-safe)
- No performance overhead

**Cons:**

- Instance created even if never used (wastes memory)
- No lazy loading
- Cannot handle exceptions during construction gracefully

**When to Use:** When instance creation is cheap and you're sure it'll be used.

---

### 2. **Lazy Initialization (NOT Thread-Safe)**

```csharp
public sealed class ConfigManager
{
    private static ConfigManager _instance;
    
    private ConfigManager()
    {
        // Load config from file/DB
    }
    
    public static ConfigManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigManager(); // RACE CONDITION!
            }
            return _instance;
        }
    }
}
```

**Problem:** In multi-threaded environment, two threads can pass the `if (_instance == null)` check simultaneously and create TWO instances. **NEVER USE THIS IN PRODUCTION.**

---

### 3. **Thread-Safe with Double-Check Locking (Most Popular)**

```csharp
public sealed class DatabaseConnectionPool
{
    private static DatabaseConnectionPool _instance;
    private static readonly object _lock = new object();
    
    private DatabaseConnectionPool()
    {
        // Expensive initialization: create connection pool
        Thread.Sleep(1000); // Simulate expensive operation
    }
    
    public static DatabaseConnectionPool Instance
    {
        get
        {
            // First check (no lock) - fast path
            if (_instance == null)
            {
                lock (_lock) // Only lock if instance is null
                {
                    // Second check (inside lock) - prevents race condition
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnectionPool();
                    }
                }
            }
            return _instance;
        }
    }
}
```

**Why Double-Check?**

1. **First check** (outside lock): If instance exists, return immediately. No lock overhead.
2. **Second check** (inside lock): Multiple threads might pass first check before lock. Second check ensures only one creates instance.

**Pros:**

- Thread-safe
- Lazy initialization (created only when needed)
- Minimal lock contention after first initialization

**Cons:**

- Slightly complex code
- Memory model issues in older .NET versions (not an issue in .NET Core)

**This is the GOLD STANDARD for SDE-2 interviews in C#.**

---

### 4. **Lazy<T> Pattern (.NET's Built-in Magic)**

```csharp
public sealed class CacheManager
{
    // Lazy<T> handles thread-safety and lazy initialization
    private static readonly Lazy<CacheManager> _instance = 
        new Lazy<CacheManager>(() => new CacheManager());
    
    private CacheManager()
    {
        // Initialize cache
    }
    
    public static CacheManager Instance => _instance.Value;
    
    public void Set(string key, object value) { /* ... */ }
    public object Get(string key) { /* ... */ }
}
```

**Pros:**

- Thread-safe by default
- Lazy initialization
- Clean, simple code
- **This is what .NET developers use in production**

**Cons:**

- Slightly less control over initialization

**When to Use:** **ALWAYS in .NET Core**. This is the modern, idiomatic way.

---

### 5. **Static Constructor Pattern**

```csharp
public sealed class AppSettingsManager
{
    private static readonly AppSettingsManager _instance;
    
    // Static constructor called automatically before first access
    static AppSettingsManager()
    {
        _instance = new AppSettingsManager();
    }
    
    private AppSettingsManager()
    {
        // Load settings
    }
    
    public static AppSettingsManager Instance => _instance;
}
```

**Pros:**

- Thread-safe (CLR guarantees)
- Lazy (static constructor runs on first access to any static member)
- No locks needed

**Cons:**

- Less obvious than Lazy<T>
- Can't pass parameters to constructor easily

---

### 6. **Dependency Injection Pattern (Modern Approach)**

```csharp
// Startup.cs in .NET Core
public void ConfigureServices(IServiceCollection services)
{
    // Register as Singleton in DI container
    services.AddSingleton<IEmailService, EmailService>();
}

// Usage in controller/service
public class OrderController : ControllerBase
{
    private readonly IEmailService _emailService;
    
    public OrderController(IEmailService emailService)
    {
        _emailService = emailService; // DI container ensures single instance
    }
}
```

**This is THE WAY in modern .NET Core applications.** Don't manually implement Singleton; let the DI container manage it.

---

## ⚠️ Critical Interview Points - Thread Safety Deep Dive

### The Race Condition Problem

```csharp
// WRONG - Race Condition
if (_instance == null)  // Thread A and B both see null
{
    _instance = new Singleton(); // Both create instances!
}
```

**What happens:**

1. Thread A checks `_instance == null` → true
2. Thread B checks `_instance == null` → true (before A creates instance)
3. Thread A creates instance
4. Thread B creates instance (DUPLICATE!)

### Why Double-Check Locking Works

```csharp
if (_instance == null)           // Fast path - no lock
{
    lock (_lock)                 // Only one thread enters
    {
        if (_instance == null)   // Winner thread creates, losers skip
        {
            _instance = new Singleton();
        }
    }
}
```

**Scenario:**

- 100 threads hit `Instance` simultaneously
- All 100 pass first check (instance is null)
- Only 1 enters lock, creates instance
- Other 99 wait on lock
- When they enter, second check fails (instance exists), they skip creation
- Future calls: First check fails immediately, no lock overhead

---

## 🎭 Real-World Use Cases (Interview Gold)

### 1. **Logger / Telemetry**

```csharp
public sealed class TelemetryClient
{
    private static readonly Lazy<TelemetryClient> _instance = 
        new Lazy<TelemetryClient>(() => new TelemetryClient());
    
    private readonly ApplicationInsights _ai;
    
    private TelemetryClient()
    {
        _ai = new ApplicationInsights("instrumentation-key");
    }
    
    public static TelemetryClient Instance => _instance.Value;
    
    public void TrackEvent(string eventName) => _ai.TrackEvent(eventName);
}
```

### 2. **Configuration Manager**

```csharp
public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _instance = 
        new Lazy<AppConfig>(() => new AppConfig());
    
    private readonly IConfigurationRoot _config;
    
    private AppConfig()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
    
    public static AppConfig Instance => _instance.Value;
    public string ConnectionString => _config["ConnectionString"];
}
```

### 3. **Database Connection Pool Manager**

```csharp
public sealed class DbConnectionPool
{
    private static readonly Lazy<DbConnectionPool> _instance = 
        new Lazy<DbConnectionPool>(() => new DbConnectionPool());
    
    private readonly List<SqlConnection> _pool;
    private readonly SemaphoreSlim _semaphore;
    
    private DbConnectionPool()
    {
        _pool = new List<SqlConnection>(10);
        _semaphore = new SemaphoreSlim(10, 10);
        InitializePool();
    }
    
    public static DbConnectionPool Instance => _instance.Value;
    
    public async Task<SqlConnection> GetConnectionAsync()
    {
        await _semaphore.WaitAsync();
        return _pool.First(c => c.State == ConnectionState.Closed);
    }
}
```

### 4. **Cache Manager**

```csharp
public sealed class CacheService
{
    private static readonly Lazy<CacheService> _instance = 
        new Lazy<CacheService>(() => new CacheService());
    
    private readonly IMemoryCache _cache;
    
    private CacheService()
    {
        _cache = new MemoryCache(new MemoryCacheOptions
        {
            SizeLimit = 1024
        });
    }
    
    public static CacheService Instance => _instance.Value;
    
    public T Get<T>(string key) => _cache.Get<T>(key);
    public void Set<T>(string key, T value, TimeSpan ttl) 
        => _cache.Set(key, value, ttl);
}
```

---

## 🚨 Common Pitfalls & Anti-Patterns

### ❌ Pitfall 1: Not Using `sealed` Keyword

```csharp
// BAD
public class Singleton { } // Can be inherited!

// GOOD
public sealed class Singleton { } // Cannot be inherited
```

**Why?** If not sealed, someone can inherit and create multiple instances:

```csharp
public class DerivedSingleton : Singleton { }
var instance1 = Singleton.Instance;
var instance2 = new DerivedSingleton(); // Breaks singleton!
```

### ❌ Pitfall 2: Forgetting Static Constructor is Called Once Per AppDomain

```csharp
// In multi-tenant apps or multiple AppDomains
// You might get multiple instances across domains
```

### ❌ Pitfall 3: Serialization Breaking Singleton

```csharp
[Serializable]
public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance = 
        new Lazy<Singleton>(() => new Singleton());
    
    private Singleton() { }
    
    public static Singleton Instance => _instance.Value;
    
    // FIX: Prevent deserialization from creating new instance
    protected Singleton GetObjectData(StreamingContext context)
    {
        return Instance;
    }
}
```

### ❌ Pitfall 4: Reflection Breaking Singleton

```csharp
// Someone can use reflection to break singleton
var constructor = typeof(Singleton).GetConstructor(
    BindingFlags.Instance | BindingFlags.NonPublic, 
    null, Type.EmptyTypes, null);
var instance = constructor.Invoke(null); // New instance!

// FIX: Throw exception in constructor if instance exists
private Singleton()
{
    if (_instance != null)
        throw new InvalidOperationException("Use Instance property");
}
```

---

## 🆚 Singleton vs Other Patterns

### Singleton vs Static Class

```csharp
// Static Class
public static class Logger
{
    public static void Log(string msg) { }
}

// Singleton
public sealed class Logger
{
    public static Logger Instance { get; }
    public void Log(string msg) { }
}
```

**Key Differences:**

|Feature|Static Class|Singleton|
|---|---|---|
|Can implement interface?|❌ No|✅ Yes|
|Can be lazy loaded?|❌ No|✅ Yes|
|Can be passed as parameter?|❌ No|✅ Yes|
|Can be mocked in tests?|❌ No|✅ Yes|
|Can have instance state?|❌ No|✅ Yes|
|Thread-safety control?|❌ Limited|✅ Full control|

**When to use Static:** Utility functions with no state (Math.Max, String.Format) **When to use Singleton:** Shared stateful resources (Logger, Cache, Config)

### Singleton vs Dependency Injection

```csharp
// Manual Singleton (Old way)
var logger = Logger.Instance;

// DI Singleton (Modern way)
services.AddSingleton<ILogger, Logger>();
public MyService(ILogger logger) { } // Injected
```

**DI Advantages:**

- Testability (easy to mock)
- Loose coupling
- Lifetime management by framework
- No global state

**In .NET Core, ALWAYS prefer DI over manual Singleton.**

---

## 🧪 Testing Singletons (Critical for Interviews)

### Problem: Singletons are Hard to Test

```csharp
// Bad - Tightly coupled
public class OrderService
{
    public void ProcessOrder()
    {
        Logger.Instance.Log("Processing..."); // Can't mock!
    }
}
```

### Solution 1: Dependency Injection

```csharp
// Good - Testable
public class OrderService
{
    private readonly ILogger _logger;
    
    public OrderService(ILogger logger)
    {
        _logger = logger;
    }
    
    public void ProcessOrder()
    {
        _logger.Log("Processing...");
    }
}

// In tests
var mockLogger = new Mock<ILogger>();
var service = new OrderService(mockLogger.Object);
```

### Solution 2: Resettable Singleton (for Tests Only)

```csharp
public sealed class TestableLogger
{
    private static TestableLogger _instance;
    
    public static TestableLogger Instance => _instance ?? (_instance = new TestableLogger());
    
    // FOR TESTS ONLY
    internal static void ResetInstance()
    {
        _instance = null;
    }
}

// In test teardown
[TestCleanup]
public void Cleanup()
{
    TestableLogger.ResetInstance();
}
```

---

## 🎯 Interview Question Scenarios

### Q1: "Why can't we use a static class instead of Singleton?"

**Answer:** "Static classes have several limitations:

1. **Cannot implement interfaces** - Makes them hard to test and swap implementations
2. **Cannot control initialization timing** - Always initialized, can't lazy load
3. **Cannot be passed as parameters** - Reduces flexibility
4. **Cannot inherit** - No polymorphism
5. **Cannot have instance-level state management** - All members must be static

Singleton gives us a real object that can implement interfaces (useful for DI), can be lazy-initialized to save resources, and can be passed around like any object. For example, in .NET Core, we register singletons in DI container as `services.AddSingleton<ILogger, Logger>()` which requires a real class, not a static one."

### Q2: "How do you ensure thread safety in Singleton?"

**Answer:** "There are three main approaches in C#:

1. **Lazy<T> (Recommended in .NET Core)**:

```csharp
private static readonly Lazy<Singleton> _instance = 
    new Lazy<Singleton>(() => new Singleton());
```

Thread-safe by default, lazy, and clean.

2. **Double-Check Locking**:

```csharp
if (_instance == null)
{
    lock (_lock)
    {
        if (_instance == null)
            _instance = new Singleton();
    }
}
```

First check avoids lock overhead after initialization. Second check inside lock prevents race condition.

3. **Static Constructor**:

```csharp
private static readonly Singleton _instance = new Singleton();
```

CLR guarantees static initialization is thread-safe.

I prefer Lazy<T> in production .NET Core code because it's explicit, modern, and has zero boilerplate."

### Q3: "What are the disadvantages of Singleton?"

**Answer:** "Singleton has several drawbacks:

1. **Hidden Dependencies** - Classes using Singleton.Instance hide dependencies, making code harder to understand
2. **Testing Difficulties** - Hard to mock, leads to tight coupling
3. **Global State** - Creates shared mutable state, which is problematic in concurrent systems
4. **Violates Single Responsibility** - Class manages both its business logic AND its lifecycle
5. **Thread-Safety Complexity** - Need careful implementation in multi-threaded environments
6. **Serialization Issues** - Deserialization can create new instances

**Modern Solution:** In .NET Core, we avoid manual Singleton and use Dependency Injection:

```csharp
services.AddSingleton<IService, Service>();
```

This gives us singleton lifetime WITHOUT the drawbacks - dependencies are explicit, testing is easy, and framework manages thread-safety."

### Q4: "Can Singleton be broken? How?"

**Answer:** "Yes, Singleton can be broken in several ways:

1. **Reflection**:

```csharp
var ctor = typeof(Singleton).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
var instance = ctor.Invoke(null); // New instance!
```

2. **Serialization/Deserialization**:

```csharp
var singleton = Singleton.Instance;
var serialized = Serialize(singleton);
var deserialized = Deserialize(serialized); // New instance!
```

3. **Multiple AppDomains** - Each AppDomain gets its own static instance

**Fixes:**

- Throw exception in constructor if instance exists
- Implement ISerializable properly to return existing instance
- Use sealed keyword to prevent inheritance"

### Q5: "Design a thread-safe Singleton Logger for a high-traffic web application"

**Answer:**

```csharp
public sealed class Logger : ILogger, IDisposable
{
    private static readonly Lazy<Logger> _instance = 
        new Lazy<Logger>(() => new Logger());
    
    private readonly ConcurrentQueue<string> _logQueue;
    private readonly StreamWriter _writer;
    private readonly Timer _flushTimer;
    private readonly SemaphoreSlim _semaphore;
    
    private Logger()
    {
        _logQueue = new ConcurrentQueue<string>();
        _writer = new StreamWriter("app.log", append: true) 
        { 
            AutoFlush = false 
        };
        _semaphore = new SemaphoreSlim(1, 1);
        
        // Flush logs every 1 second (batching for performance)
        _flushTimer = new Timer(async _ => await FlushLogsAsync(), 
            null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
    }
    
    public static Logger Instance => _instance.Value;
    
    public void Log(string message)
    {
        var logEntry = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message}";
        _logQueue.Enqueue(logEntry);
    }
    
    private async Task FlushLogsAsync()
    {
        if (_logQueue.IsEmpty) return;
        
        await _semaphore.WaitAsync();
        try
        {
            while (_logQueue.TryDequeue(out var log))
            {
                await _writer.WriteLineAsync(log);
            }
            await _writer.FlushAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
    
    public void Dispose()
    {
        _flushTimer?.Dispose();
        FlushLogsAsync().Wait();
        _writer?.Dispose();
        _semaphore?.Dispose();
    }
}
```

**Key Points I'd Mention:**

- Uses Lazy<T> for thread-safe initialization
- ConcurrentQueue for lock-free log enqueueing (high throughput)
- Batched writes every 1 second (reduces I/O overhead)
- SemaphoreSlim for async-friendly synchronization during flush
- Implements IDisposable for cleanup
- AutoFlush = false for better performance

---

## 📊 Performance Considerations

### Memory Overhead

```csharp
// Eager - Always uses memory
private static readonly Singleton _instance = new Singleton(); // ~1KB

// Lazy - Uses memory only when accessed
private static readonly Lazy<Singleton> _instance = 
    new Lazy<Singleton>(() => new Singleton()); // ~64 bytes until accessed
```

**For .NET Core apps:** Lazy<T> overhead is negligible (~64 bytes). Use it unless you have strong reasons not to.

### Lock Contention

```csharp
// BAD - Lock on every access
public static Singleton Instance
{
    get
    {
        lock (_lock) // Every thread waits here!
        {
            return _instance ?? (_instance = new Singleton());
        }
    }
}

// GOOD - Double-check locking
public static Singleton Instance
{
    get
    {
        if (_instance == null) // Fast path - no lock
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Singleton();
            }
        }
        return _instance;
    }
}
```

**Benchmark (1M access calls):**

- Always-lock: ~500ms
- Double-check: ~50ms
- Lazy<T>: ~50ms

---

## 🎓 Summary Cheat Sheet

### When to Use Singleton

✅ Logger/Telemetry  
✅ Configuration Manager  
✅ Cache Manager  
✅ Connection Pool  
✅ Hardware interface (printer, scanner)

### When NOT to Use Singleton

❌ User session data (not shared)  
❌ Business logic classes (should be stateless)  
❌ Database context (should be per-request)  
❌ When you need multiple instances later

### Modern .NET Core Approach

```csharp
// Startup.cs
services.AddSingleton<IEmailService, EmailService>();

// Usage
public class OrderController
{
    private readonly IEmailService _emailService;
    public OrderController(IEmailService emailService)
    {
        _emailService = emailService;
    }
}
```

### Quick Implementation (Copy-Paste Ready)

```csharp
public sealed class YourSingleton
{
    private static readonly Lazy<YourSingleton> _instance = 
        new Lazy<YourSingleton>(() => new YourSingleton());
    
    private YourSingleton()
    {
        // Initialize resources
    }
    
    public static YourSingleton Instance => _instance.Value;
    
    // Your methods here
}
```

---

## 🎤 The 30-Second Interview Answer

"Singleton ensures a class has only one instance throughout the application lifetime, with global access. I use it for shared resources like loggers, cache managers, or connection pools. In .NET Core, I prefer using `Lazy<T>` for thread-safe implementation or better yet, register it as `services.AddSingleton()` in the DI container. The main challenges are thread-safety—solved with double-check locking or Lazy<T>—and testability—solved by using dependency injection instead of static Instance property."

---

**Now go ace that interview! 🚀 You've got this covered from every angle.**
