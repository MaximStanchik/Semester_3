#include "stdafx.h"

string readDataFromFile(const string& filename) {
	ifstream file(filename);
    if (!file) {
        cout << "Ошибка открытия файла." << endl;
        return "";
    }
    else {
        stringstream buffer;
        buffer << file.rdbuf();  

        file.close();

        return buffer.str();
    }
}