#pragma once
#include "stdafx.h"

template <typename T>
string getDataAboutAFundamentalTypeLiteral(const T& variable)
{
    size_t sizeOfVariable = sizeof(variable);
    const type_info& typeOfVariable = typeid(variable);

    string type = typeOfVariable.name();
    if (type == "int") {
        type = "0";
    }
    else if (type == "unsigned int") {
        type = "1";
    }
    string size = to_string(sizeOfVariable);
    string value = to_string(variable);

    string serializedData =  type + size + value + ";";

    return serializedData;
}
