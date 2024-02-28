#include "stdafx.h"

bool checkSubnetMask(const string& subnetMask) {
    unsigned int mask = stoi(subnetMask);

    unsigned int invertedMask = ~mask; 
    unsigned int checkMask = invertedMask & (invertedMask + 1); 

    return checkMask == 0;
}