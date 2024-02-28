#include <iostream>
#include "toCheckInput.h"
using namespace std;

int counter = 0;

void toSolveTowerOfHanoi(int i, int k, int N)
{
    counter++;
    if (N == 1) {
        cout << "����������� ���� 1 � " << i << " �� " << k << " ��������." << endl;
    }
    else{
        int auxiliaryRod = 6 - i - k;
        toSolveTowerOfHanoi(i, auxiliaryRod, N - 1);
        cout << "����������� ���� " << N << " � " << i << " �� " << k << " ��������." << endl;
        toSolveTowerOfHanoi(auxiliaryRod, k, N - 1);
    }
}

int main()
{
    system("chcp 1251>nul");
    int N{}, k{};

    while (true)
    {
        cout << "������� ���������� ������: " << endl;
        cin >> N;
        if (toCheckInput(N)==false) {
            cout << "�� ����� ������������ �������� N, ���������� ��� ���" << endl;
            continue;
        }
        else {
            cout << "������� ����� �������, �� ������� ����� ����������� ����� (2 ��� 3): ";
            cin >> k;
            if (toCheckInput(N) == false || k > 3)
            {
                cout << "�� ����� ������������ �������� k, ���������� ��� ���" << endl;
                continue;
            }
            else if (k==1) {
                cout << "������ ������, �.�. ����� ���������� ����� �� ������� �� ������� �� �� ������ ����������" << endl;
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