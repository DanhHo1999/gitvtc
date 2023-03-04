#include<iostream>
using namespace std;
int main() {
	cout << "Nhap N: "; int n; cin >> n;
	
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= ((n - 1) * 2) + 1; j++) {
			if (j <= (n - i))cout << " ";
			if (j > (n - i) && j < (n + i))cout << "*";
		}cout << endl;
	}
}