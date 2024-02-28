#include <iostream>
#include "toCheckInput.h"
using namespace std;

int counter = 0;

void toSolveTowerOfHanoi(int i, int k, int N)
{
    counter++;
    if (N == 1) {
        cout << "Переместить диск 1 с " << i << " на " << k << " стержень." << endl;
    }
    else{
        int auxiliaryRod = 6 - i - k;
        toSolveTowerOfHanoi(i, auxiliaryRod, N - 1);
        cout << "Переместить диск " << N << " с " << i << " на " << k << " стержень." << endl;
        toSolveTowerOfHanoi(auxiliaryRod, k, N - 1);
    }
}

int main()
{
    system("chcp 1251>nul");
    int N{}, k{};

    while (true)
    {
        cout << "Введите количество дисков: " << endl;
        cin >> N;
        if (toCheckInput(N)==false) {
            cout << "Вы ввели неправильное значение N, попробуйте ещё раз" << endl;
            continue;
        }
        else {
            cout << "Введите номер стрежня, на которые нужно переместить диски (2 или 3): ";
            cin >> k;
            if (toCheckInput(N) == false || k > 3)
            {
                cout << "Вы ввели неправильное значение k, попробуйте ещё раз" << endl;
                continue;
            }
            else if (k==1) {
                cout << "Задача решена, т.к. диски изначально лежат на стержне на который Вы их хотите переложить" << endl;
                return 0;
            }
            else
            {
                toSolveTowerOfHanoi(1, k, N);
                break;
            }
        }
        
    }
    system("pause");
    return 0;
}