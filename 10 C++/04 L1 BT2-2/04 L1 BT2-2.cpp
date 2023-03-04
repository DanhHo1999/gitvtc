#include <iostream>
using namespace std;
int main()
{
	cout << "Nhap tuoi: "; int tuoi; cin >> tuoi;
	if (tuoi <= 0)cout << "Loi" << endl;
	else if (tuoi <= 13)cout << "100 nghin" << endl;
	else if (tuoi<56)cout << "200 nghin" << endl;
	else cout << "300 nghin" << endl;
	
}