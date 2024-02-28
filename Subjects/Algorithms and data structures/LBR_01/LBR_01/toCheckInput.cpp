#include <iostream>
#include "toCheckInput.h"
using namespace std;

bool toCheckInput(int variable) {
    if (cin.get() != (int)'\n') {
        cin.clear();
        cin.ignore(32767, '\n');
        return false;
    }
    else if (variable <= 0 || variable > 1000) {
        return false;
    }
    else {
        return true;
    }
}


