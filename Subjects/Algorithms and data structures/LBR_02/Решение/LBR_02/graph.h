#ifndef GRAPH_H
#define GRAPH_H

#include <vector>
#include <queue>

class Graph {
public:
    Graph(int numVertices);

    void addEdge(int vertex1, int vertex2, int weight);
    void primMST();

private:
    std::vector<std::vector<std::pair<int, int>>> adjacencyList;
    int numVertices;

};

#endif
