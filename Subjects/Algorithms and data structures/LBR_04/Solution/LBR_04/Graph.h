#pragma once
#include <vector>
#include <queue>
#include <unordered_map>
#include <climits> 
#include <cmath>

using namespace std;

struct Edge {
	int finalVertex;
	int weight;
};

class Graph {
private:
	unordered_map<int, vector<Edge>> graphAdjacencyList;
public:
	vector<vector<float>> D0Matrix();
	vector<vector<float>> S0Matrix();
	void floydWarshall(vector<vector<float>>& matrix, vector<vector<float>>& newMare);
	void printMatrix(const vector<vector<float>>& matrix);
};