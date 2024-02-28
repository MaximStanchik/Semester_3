#include "AntColony.h"

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	srand(time(0));

	int N = 0, A = 0, B = 0, alpha = 0, betta = 0, q = 0;

	while (true)
	{
		cout << "������� ���������� ������: ";
		cin >> N;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (N <= 0)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}
	int** D = new int* [N];

	cout << "������� ����������:" << endl;
	for (int i = 0; i < N; ++i)
	{
		D[i] = new int[N];
		for (int j = 0; j < N; ++j)
			if (i == j)
				D[i][j] = 0;
			else
				D[i][j] = randNum(1, 100);
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)  //�����, ����, ��������, ��� �� �������� �����, �� ����
			cout << D[i][j] << '\t';  //� 9.35 � 322-1. 
		cout << endl;
	}
	// ������������� ��������� � �������� �����
	while (true)
	{
		cout << "������� ��������� ������� �� 1 �� " << N << ": ";
		cin >> A;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (A < 1 || A > N)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}
	while (true)
	{
		cout << "������� �������� ������� �� 1 �� " << N << " �������� " << A << ": ";
		cin >> B;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (B < 1 || B > N || B == A)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}
	while (true)
	{
		cout << "������� �����: ";
		cin >> alpha;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (alpha < 0)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}
	while (true)
	{
		cout << "������� ����: ";
		cin >> betta;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (betta < 0)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}
	while (true)
	{
		cout << "������� ���������� ��������: ";
		cin >> q;
		if (cin.get() != (int)'\n')
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			cin.clear();
			cin.ignore(32767, '\n');
			continue;
		}
		else if (q < 0)
		{
			cout << "\n---------- ������ ������� �������, ���������� ��� ��� --------------" << endl;
			continue;
		}
		else
			break;
	}


	AntColony start(alpha, betta, q);
	AntWay way = start.AntColonyOptimization(D, N, --A, --B);

	cout << "����� ����: " << way.length << endl;
	cout << "����: " << ++way.tabu[0];
	for (int i = 1; i < way.itabu; ++i)
		cout << " - " << ++way.tabu[i];

	return 0;
}