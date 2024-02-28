#include "Graph.h"
#include <iostream>
#include <queue>

Graph::Graph(int numVertices) {
    this->numVertices = numVertices;
    adjacencyList.resize(numVertices);
}

void Graph::addEdge(int vertex1, int vertex2, int weight) {
    adjacencyList[vertex1].push_back(std::make_pair(vertex2, weight));
    adjacencyList[vertex2].push_back(std::make_pair(vertex1, weight));
}

void Graph::primMST() {
    std::vector<bool> visited(numVertices, false);
    std::vector<int> minWeight(numVertices, INT_MAX);
    std::vector<int> parent(numVertices, -1);

    minWeight[0] = 0;

    std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>> pq;
    pq.push(std::make_pair(0, 0));

    while (!pq.empty()) {
        int u = pq.top().second;
        pq.pop();

        visited[u] = true;

        for (auto& edge : adjacencyList[u]) {
            int v = edge.first;
            int weight = edge.second;

            if (!visited[v] && weight < minWeight[v]) {
                parent[v] = u;
                minWeight[v] = weight;
                pq.push(std::make_pair(minWeight[v], v));
            }
        }
    }

    for (int i = 1; i < numVertices; i++) {
        std::cout << parent[i] << " - " << i << std::endl;
    }
}