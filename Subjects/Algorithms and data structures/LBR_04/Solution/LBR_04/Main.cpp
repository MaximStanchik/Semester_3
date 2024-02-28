#include <iostream>
#include "Graph.h"

using namespace std;

int main() {

	Graph graph;

	cout << "D0 matrix output: " << endl;
	graph.printMatrix(graph.D0Matrix());

	cout << "\nS0 matrix output:" << endl;
	graph.printMatrix(graph.S0Matrix());

	vector<vector<float>> D = graph.D0Matrix();
	vector<vector<float>> S = graph.S0Matrix();
	
	graph.floydWarshall(D, S);

	cout << "\nMatrix D using the Floyd-Warshell algorithm:" << endl;
	graph.printMatrix(D);

	cout << "\nMatrix S using the Floyd-Warshell algorithm:" << endl;
	graph.printMatrix(S);

	system("pause");
	return 0;
}
	