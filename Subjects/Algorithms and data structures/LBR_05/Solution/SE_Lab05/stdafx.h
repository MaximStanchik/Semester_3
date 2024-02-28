#pragma once
#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>
#include "Graph.h"
#include "DisjointSet.h"

using namespace std;

vector<vector<float>> toBuildAnOriginalGraphAdjacencyMatrix();
void toPrintMatrix(const vector<vector<float>>& matrix);