#include "stdafx.h"
#include "NumberCheck.h"

struct Product {
	string name;
	double weight;
	double cost;
};

bool compareByWeight(const tuple<string, double, double>& a, const tuple<string, double, double>& b) {
	return get<1>(a) < get<1>(b);
}


unordered_map<int, tuple<string, double, double>> infoAboutAllProducts;

int main() {
	int productCounter{};
	setlocale(LC_ALL, "Rus");

	double backpackCapacity{};
	string userEnteredValue{};

enteringBackpackCapacity:
	cout << "�������, ����������, ����������� ������� (��):";
	cin >> userEnteredValue;
	if (checkNumber(userEnteredValue) == false) {
		cout << "�� ����� �������� ��������. ��������� ����." << endl;
		goto enteringBackpackCapacity;
	}
	else {
		backpackCapacity = stod(userEnteredValue);
	}

	vector<Product> sortedInfoAboutAllProducts;

	string productName{};
	string productWeightEnteredByTheUser{};
	string costOfGoodsEnteredByTheUser{};
    double productWeight{};
	double costOfGoods{};

enteringProductInformation:
	cout << "������� ���������� � ������ (��������, ��� ������ � ��������� ������):" << endl;
	cout << "��������:";
	cin >> productName;
	cout << "���:";
	cin >> productWeightEnteredByTheUser;
	cout << "���������:";
	cin >> costOfGoodsEnteredByTheUser;

	if (checkNumber(productWeightEnteredByTheUser) == false || checkNumber(costOfGoodsEnteredByTheUser) == false) {
		cout << "�� ����� �������� ��������. ��������� ����." << endl;
		goto enteringProductInformation;
	}
	else {
		productWeight = stod(productWeightEnteredByTheUser);
		costOfGoods = stod(costOfGoodsEnteredByTheUser);
	}

	productCounter++;

	Product newProduct;
	newProduct.name = productName;
	newProduct.weight = productWeight;
	newProduct.cost = costOfGoods;

	sortedInfoAboutAllProducts.push_back(newProduct);

	infoAboutAllProducts[productCounter] = make_tuple(productName, productWeight, costOfGoods);

	int selectionOfValueInput{};
	cout << "�� ������ ������ ���������� ��� �� ����� ������?" << endl;
	cout << "1--��" << endl;
	cout << "2--���" << endl;
actionInputSelection:
	cin >> selectionOfValueInput;
	switch (selectionOfValueInput) {
	case 1: {
		goto enteringProductInformation;
		break;
	}
	case 2: {
		break;
	}
	default: {
		cout << "������� �������� ��������. ���������� ��� ���." << endl;
		goto actionInputSelection;
		break;
	}
	}
	cout << "--------------------------------------------------------" << endl;
	cout << "����������� ������:" << endl;
	for (const auto& item : infoAboutAllProducts) {
		int key = item.first;
		string name = get<0>(item.second);
		double weight = get<1>(item.second);
		double cost = get<2>(item.second);

	    cout << "����� " << key << ": " << endl;
		cout << "��������: " << name << endl;
		cout << "���: " << weight << endl;
		cout << "���������: " << cost << endl;
	}
	cout << "--------------------------------------------------------" << endl;

	vector<vector<double>> dp(productCounter + 1, vector<double>(backpackCapacity + 1, 0.0));

	for (int i = 1; i <= productCounter; i++) {
		for (int j = 1; j <= backpackCapacity; j++) {
			double weight = sortedInfoAboutAllProducts[i - 1].weight;
			double cost = sortedInfoAboutAllProducts[i - 1].cost;

			if (weight > j) {
				dp[i][j] = dp[i - 1][j];
			}
			else {
				dp[i][j] = max(dp[i - 1][j], dp[i - 1][j - weight] + cost);
			}
		}
	}

	vector<Product> selectedProducts;

	int i = productCounter;
	int j = backpackCapacity;

	while (i > 0 && j > 0) {
		if (dp[i][j] != dp[i - 1][j]) {
			selectedProducts.push_back(sortedInfoAboutAllProducts[i - 1]);
			j -= sortedInfoAboutAllProducts[i - 1].weight;
		}
		i--;
	}

	cout << "��������� ������:" << endl;
	for (int i = selectedProducts.size() - 1; i >= 0; i--) {
		cout << "��������: " << selectedProducts[i].name << endl;
		cout << "���: " << selectedProducts[i].weight << endl;
		cout << "���������: " << selectedProducts[i].cost << endl;
	}

	double maxCost = dp[productCounter][backpackCapacity];
	cout << "������������ ���������: " << maxCost << endl;

	system("pause");
	return 0;
}































//while (i > 0 && j > 0) {
//	if (dp[i][j] != dp[i - 1][j]) {
//		if (sortedInfoAboutAllProducts[i - 1].weight == j) {
//			// �������������� �������: �������� ����� � ���������� �����
//			selectedProducts.push_back(sortedInfoAboutAllProducts[i - 1]);
//			break;
//		}
//		else if (sortedInfoAboutAllProducts[i - 1].weight < j) {
//			// �������������� �������: �������� ����� � ���������� �����
//			if (dp[i][j] == dp[i - 1][j - sortedInfoAboutAllProducts[i - 1].weight] + sortedInfoAboutAllProducts[i - 1].cost) {
//				selectedProducts.push_back(sortedInfoAboutAllProducts[i - 1]);
//				j -= sortedInfoAboutAllProducts[i - 1].weight;
//			}
//		}
//	}
//	i--;
//}