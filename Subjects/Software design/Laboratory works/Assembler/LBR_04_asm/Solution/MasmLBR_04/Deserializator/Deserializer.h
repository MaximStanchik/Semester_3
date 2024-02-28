#pragma once
#include "stdafx.h"

vector<string> splitString(const string& inputString); 
tuple<char, char, string> processString(const string& input);
void writeToAssemblyFile(const string& fileName, const string& variableName, const string& value);