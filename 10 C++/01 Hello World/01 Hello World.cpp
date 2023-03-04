#include <iostream>
using namespace std;
int main()
{
    cout << "START"<<endl;

    int a = 1;
    float b = 2;
    double c = 3;
    long d = 4;
    bool e = true;
    bool f = false;
    string g = "B";

    cout << "Size of int = " << sizeof(a) << endl;
    cout << "Size of float = " << sizeof(b) << endl;
    cout << "Size of double = " << sizeof(c) << endl;
    cout << "Size of long = " << sizeof(d) << endl;
    cout << "Size of bool = " << sizeof(e) << endl;
    cout << "Size of string = " << sizeof(g) << endl;

    const int MAX = 3;
    
    int x;
    cout << "Nhap X:";
    cin >> x;
    cout << "X = " << x << endl;

}
