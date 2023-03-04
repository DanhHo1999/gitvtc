#include <iostream>
#include <iomanip>
using namespace std;
const double pi = 3.14159265358979323846;
int main() {
	cout << "1. Tam giac"<<endl;
	cout << "2. Hinh tron"<<endl;
	cout << "3. Hinh Hinh chu nhat"<<endl;
	int x;
	cin >> x;
	if (x == 1) {
		cout << "Nhap 3 canh cua tam giac " << endl << "A: ";
		double a; cin >> a;
		cout << "B: "; double b; cin >> b;
		cout << "C: "; double c; cin >> c;
		if ((a + b) <= c) { cout << "Tam Giac Loi. Exit."; return 0; }
		if ((a + c) <= b) { cout << "Tam Giac Loi. Exit."; return 0; }
		if ((c + b) <= a) { cout << "Tam Giac Loi. Exit."; return 0; }
		double p = (a + b + c) / 2;
		double S = sqrt(p * (p - a) * (p - b) * (p - c));
		cout << "Dien tich tam giac la: " << setprecision(2) << fixed << S << endl;
	}
	if (x == 2) {
		cout << "Nhap ban kinh: "; double r; cin >> r;
		cout << "Dien tich hinh tron la: " << setprecision(2) << fixed << (pi*r*r);
	}
	if (x == 3) {
		cout << "Nhap chieu dai: "; int a; cin >> a;
		cout << "Nhap chieu rong: "; int b; cin >> b;
		cout << "Dien tich hinh chu nhat la: " << a*b;
	}
}