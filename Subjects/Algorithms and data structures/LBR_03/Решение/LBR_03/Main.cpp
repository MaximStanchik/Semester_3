#include <iostream>
#include "Graph.h"

using namespace std;

int main() {
    char startingVertex;
    Graph graph;

    graph.addEdge('A', 'B', 7);
    graph.addEdge('A', 'C', 10);
    graph.addEdge('C', 'F', 8);
    graph.addEdge('B', 'F', 9);
    graph.addEdge('B', 'G', 27);
    graph.addEdge('F', 'H', 11);
    graph.addEdge('G', 'I', 15);
    graph.addEdge('H', 'I', 15);
    graph.addEdge('C', 'E', 31);
    graph.addEdge('E', 'D', 32);
    graph.addEdge('H', 'D', 17);
    graph.addEdge('I', 'D', 21);

    cout << "Graph Implementation: " << endl;
    graph.printGraph();

    cout << "Please indicate the starting vertex: ";
    cin >> startingVertex;

    unordered_map<char, int> distances = graph.dijkstra(startingVertex);

    cout << "Shortest distances from the top " << startingVertex << ":\n";
    for (const auto& distance : distances) {
        cout << "To the top " << distance.first << ": " << distance.second << endl;
    }

    system("pause");
    return 0;
}