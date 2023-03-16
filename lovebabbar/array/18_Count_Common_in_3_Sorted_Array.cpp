#include <bits/stdc++.h>

using namespace std;

int main() {

    // Simple Process

    // JUST CREATE VECTOR D -> common from a & b | Use Two Pointer
    // Now CREATE VECTOR ANS -> common from c & D 👌

    // AND... WHEN YOU GOT common element DURING TWO POINTER 
    // RUN WHILE LOOP in the same ----> TO IGNORE DUPLICATES ⭐

    vector<int> a = {1, 5, 10, 20, 40, 80}, b = {6, 7, 20, 80, 100}, c = {3, 4, 15, 20, 30, 70, 80, 120};

    vector<int> d, ans;

    int n1 = a.size(), n2 = b.size(), n3 = c.size();
    int i = 0, j = 0;

    while (i < n1 && j < n2) {
        if (a[i] < b[j])
            i++;
        else if (a[i] > b[j])
            j++;
        else {
            int common = a[i];
            d.push_back(common);
            while (i < n1 && a[i] == common) i++;
            while (j < n2 && b[j] == common) j++;
        }
    }

    i = 0;
    j = 0;

    while (i < d.size() && j < n3) {
        if (d[i] < c[j])
            i++;
        else if (d[i] > c[j])
            j++;
        else {
            int common = d[i];
            ans.push_back(common);
            while (i < d.size() && d[i] == common) i++;
            while (j < n3 && c[j] == common) j++;
        }
    }

    for (auto it : ans) cout << it << " ";

    return 0;
}