#include "stdafx.h"

bool checkNumber(const string& numberEnteredByTheUser) {
    if (numberEnteredByTheUser.empty()) {
        return false;
    }

    for (char c : numberEnteredByTheUser) {
        if (!std::isdigit(c)) {
            return false;
        }
    }

    return true;
}