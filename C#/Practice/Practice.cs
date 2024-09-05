namespace Practice;

public class Practice {

    public class Animal {
        public virtual void MakeSound(string animal) {
            System.Console.WriteLine("Animal sound");
        }
    }

    public class Dog : Animal {
        public override void MakeSound(string animal)
        {   
            if(animal == "dog") {
                System.Console.WriteLine("bark");
            } 
            else {
                base.MakeSound(animal);
            }
        }
    }

    public static void Run() {
        var animal = new Dog();

        animal.MakeSound("BBB");    
        animal.MakeSound("dog");    
    }
}