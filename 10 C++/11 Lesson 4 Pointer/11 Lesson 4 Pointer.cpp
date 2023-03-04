#include <iostream>
using namespace std;

void changeValue(int* a, int newValue) {
	*a = newValue;
}
float avg(int* arr, int length) {
	int sum = 0;
	for (int i = 0; i < length; i++) {
		sum += arr[i];
	}
	return (float)sum / length;
}
int* getRandom() {
	
	int r = rand() % 10; cout << "r = " << r << " ";
	int* p = &r;
	return p;
}
int* generateArray() {
	srand(time(NULL));
	static int arr[5] = { rand()%10, rand() % 10, rand() % 10, rand() % 10, rand() % 10 };
	return arr;
}void printArray(int* arr, int length) {
	for (int i = 0; i < length; i++) {
		cout << arr[i] << " ";
	}
	cout << endl;
}
int* copySortArrayAsc(int* arr, int length) {
	static int newArray[100];
	for (int i = 0; i < length; i++) {
		newArray[i] = arr[i];
	}
	for (int i = 0; i < (length - 1); i++) {
		for (int j = (i + 1); j < length; j++) {
			if (newArray[i] > newArray[j]) {
				int temp = newArray[i];
				newArray[i] = newArray[j];
				newArray[j] = temp;
			}

		}

	}return newArray;
}
void sortArrayAsc(int* arr, int length) {

	for (int i = 0; i < (length-1); i++) {
		for (int j = (i+1); j < length; j++) {
			if (arr[i] > arr[j]) {
				int temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
			
		}
		
	}
}
int** GenerateArray2DPointer(int m, int n) {
	int** array2D = new int* [m];
	for (int i = 0; i < m; i++) {
		array2D[i] = new int[n];
	}
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			array2D[i][j] = 9;
		}
	}

	return array2D;
}
void printArray2D(int** array2D,int m,int n) {
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			cout << array2D[i][j] << " ";
		}
		cout << endl;
	}
}
int main() {
	
	int a = 10;
	int* ptr = &a;
	
	int** ptr2 = &ptr;
	

	
	int*** ptr3 = &ptr2;
	cout << ptr3[0][0][0] << endl;
	cout << ***ptr3<<"\n";
	//    cout << *ptr <=> cout << ptr[0]

	a = 5;
	cout << a<<endl;
	changeValue(&a, 10);
	cout << a << endl;

	int arr[5] = { 1,2,3,4,5 };
	//ptr = arr; <=> ptr=&arr[0]
	float _avg = avg(&arr[0], 5);
	cout << "avg = " << _avg << endl;
	_avg = avg(&arr[1], 4);
	cout << "avg = " << _avg << endl;
	int* ran = getRandom();
	cout << *ran << endl << endl;

	int* arr2 = generateArray();
	printArray(arr2, 5);
	int* arr3= copySortArrayAsc(arr2, 5);
	printArray(arr3, 5);
	printArray(arr2, 5);
	cout << endl << endl;

	//Array2DPointer
	printArray2D(GenerateArray2DPointer(5, 5),5,5);
}