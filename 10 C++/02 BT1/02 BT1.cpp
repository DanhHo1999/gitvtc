
#include <iostream>
using namespace std;


int main()
{
    int n;
    cin >> n;
    int total=0;
    for (int i = 0; i < n; i++) {
        int x;
        cout << "So thu " << i + 1 << ": ";
        cin >> x;
        if (x % 2 == 1) {
            cout << "Total = " << total << " + " << x << " = ";
            total += x;
            cout << total << endl;
        }
    }
    cout << "Total: " << total << endl;
}