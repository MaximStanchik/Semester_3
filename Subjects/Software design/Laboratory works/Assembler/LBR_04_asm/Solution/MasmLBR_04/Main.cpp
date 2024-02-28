#include "stdafx.h"
#include "Serializer.h"
#include "GettingDataAboutLiteral.h"

int main() {
    setlocale(LC_ALL, "Rus");

    int needToCleanTheFile{};
    int choiceOfAction{};
    unsigned int numberOfunsignedIntTypeEnteredByUser{};
    int numberOfIntTypeEnteredByUser{};

    cout << "Введите положительное целое число: ";
    cin >> numberOfunsignedIntTypeEnteredByUser;
    cout << "Введите целое число: ";
    cin >> numberOfIntTypeEnteredByUser;
    cout << endl;
    cout << "unsigned int -- 0" << endl;
    cout << "int          -- 1" << endl << endl;
    string serializedDataOfUnsignedIntLiteral = getDataAboutAFundamentalTypeLiteral(numberOfunsignedIntTypeEnteredByUser);
    string serializedDataOfIntLiteral = getDataAboutAFundamentalTypeLiteral(numberOfIntTypeEnteredByUser);
enteringValue:
    cout << "Нужно очистить файл, содержащий метаданные?" << endl;
    cout << "1--Очистить файл перед выполненией сериализации" << endl;
    cout << "2--Не очищать файл перед выполненией сериализации" << endl;
    cin >> choiceOfAction;
    if (choiceOfAction == 1) {
        cout << "Файл, содержащий метаданные, будет очищен перед выполнением сериализации" << endl;
        SerealizeData(serializedDataOfUnsignedIntLiteral, 1);
        SerealizeData(serializedDataOfIntLiteral, 0);
    }
    else if (choiceOfAction == 2) {
        cout << "Файл, содержащий метаданные, не будет очищен перед выполнением сериализации" << endl;
        SerealizeData(serializedDataOfUnsignedIntLiteral, 0);
        SerealizeData(serializedDataOfIntLiteral, 0);
    }
    else {
        cout << "Введено неверное значение. Введите его еще раз." << endl;
        goto enteringValue;
    }

    system("pause");
    return 0;
}