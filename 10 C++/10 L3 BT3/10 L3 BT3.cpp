#include <iostream>
using namespace std;
int main()
{
    string a = "abcd abc abcd a bc abcdeee cdeee ab abee";
    string b = "ab";
    string c = "t";
    a = a.replace(0, 2, "ta");
    cout << a;
}