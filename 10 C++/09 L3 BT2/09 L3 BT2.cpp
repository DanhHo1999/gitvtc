#include <iostream>
using namespace std; 
int CountWords(string a, string b) {
	size_t found = a.find(b);
	int count = 0;
	while (found != string::npos) {
		count++;
		a = a.substr(found + b.length());
		found = a.find(b);
	}
	return count;
}
int main() {
	string a = "abc de ab aaa ab aaaa";
	string b = "b";
	cout << "So lan chuoi 2 xuat hien trong chuoi 1: " << CountWords(a, b);

}
