#include <bits/stdc++.h>
using namespace std;
using ll = long long;

#define vi vector<int>
#define vl vector<ll>
#define vpi vector<pair<int, int>>
#define vpl vector<pair<ll, ll>>
#define seti set<int>
#define setl set<ll>
#define mseti multiset<int>
#define msetl multiset<ll>
#define mapi map<int, int>
#define mapl map<ll, ll>
#define mmapi multimap<int, int>
#define mmapl multimap<ll, ll>
#define umapi unordered_map<int, int>
#define umapl unordered_map<ll, ll>
#define fol(x, a, b) for (ll x = a; x < b; x++)
#define foi(x, a, b) for (int x = a; x < b; x++)
#define rfoi(x, a, b) for (int x = a; x >= b; x--)
#define itr(it, v) for (auto it = v.begin(); it != v.end(); it++)
#define rit(v) for (auto it = v.rbegin(); it != v.rend(); it++)
#define all(v) v.begin(), v.end()
#define asort(v) sort(all(v))
#define dsort(v) sort(v.rbegin(), v.rend())
#define lb(v, x) lower_bound(v.begin(), v.end(), x)
#define ub(v, x) upper_bound(v.begin(), v.end(), x)
#define dbgv(it, v) \
    for (auto it = v.begin(); it != v.end(); it++) cout << *it << " "
#define dbgm(it, m) \
    for (auto it = m.begin(); it != m.end(); it++) cout << it->first << " " << it->second << endl
#define endl "\n"
#define el cout << endl;
#define F first
#define S second
#define MP make_pair
#define PB push_back
#define Imax INT_MAX
#define Imin INT_MIN
#define Lmax LLONG_MAX
#define Lmin LLONG_MIN
#define MOD 1000000007

#define dbg(x) cout << #x << ": " << x << endl
#define dbg2(x, y) cout << #x << ": " << x << " | " << #y << ": " << y << endl
#define dbg3(x, y, z) cout << #x << ":" << x << " | " << #y << ": " << y << " | " << #z << ": " << z << endl
#define dbg4(a, b, c, d) cout << #a << ": " << a << " | " << #b << ": " << b << " | " << #c << ": " << c << " | " << #d << ": " << d << endl

const double PI = 3.1415926535897;

void FastIO() {
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);
}

void INOUT() {
#ifndef ONLINE_JUDGE
    freopen("input.txt", "r", stdin);
    freopen("output.txt", "w", stdout);
#endif
}

// ////////////////////////////////////Let's crack it//////////////////////////////////////////////////////////////////////////////

bool sortbysec(const pair<int, int> &a,
               const pair<int, int> &b) {
    return (a.second < b.second);
}

int sumOfDigits(int num) {
    int ans = 0;
    while (num) {
        ans += (num % 10);
        num /= 10;
    }
    return ans;
}

void solve() {

    vi a = {18, 43, 36, 13, 7};

    int n = a.size();

    sort(a.begin(), a.end());

    map<int, vector<int>> mp;

    for (int i = 0; i < n; i++) {
        int sum = sumOfDigits(a[i]);
        mp[sum].push_back(a[i]);
    }

    for (auto it : mp) {
        cout << it.first << " : ";
        for (auto vt : it.second) cout << vt << " ";
        cout << endl;
    }

    int ans = -1;
    for (auto it : mp) {
        int len = it.second.size();
        if (len >= 2) {
            ans = max(ans, it.second[len - 1] + it.second[len - 2]);
        }
    }
    cout << ans << endl;
}

int main() {
    FastIO();
    INOUT();

    int TeStCaSeS;
    // TeStCaSeS = 1;
    cin >> TeStCaSeS;

    while (TeStCaSeS--) {
        solve();
    }
    return 0;
}