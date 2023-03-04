#include <iostream>
using namespace std;
int main() {
	int count=0, total=0;
	for (int i = 99; i > 0; i--) {
		if (i % 2 == 1) {
			count++;
			total += i;
			cout << i<<" ";
			if (count == 10)break;
		}
	}
	cout << total;
}