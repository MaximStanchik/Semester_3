#include "Graph.h"
#include <iostream>

void Graph::addEdge(char source, char destination, int weight) {
    adjacencyList[source].push_back({ destination, weight });
    adjacencyList[destination].push_back({ source, weight });
}

void Graph::printGraph() {
    for (const auto& vertex : adjacencyList) {
        std::cout << "Vertex " << vertex.first << " is connected to: ";
        for (const auto& edge : vertex.second) {
            std::cout << edge.destination << " (weight: " << edge.weight << "), ";
        }
        std::cout << std::endl;
    }
}

std::unordered_map<char, int> Graph::dijkstra(char startVertex) {
    std::unordered_map<char, int> distances;
    std::priority_queue<std::pair<int, char>, std::vector<std::pair<int, char>>, std::greater<std::pair<int, char>>> pq;
    std::unordered_map<char, bool> visited;

    for (const auto& vertex : adjacencyList) {
        char vertexId = vertex.first;
        distances[vertexId] = (vertexId == startVertex) ? 0 : INT_MAX;
        visited[vertexId] = false;
    }

    pq.push({ 0, startVertex });

    while (!pq.empty()) {
        char currentVertex = pq.top().second;
        pq.pop();

        if (visited[currentVertex]) {
            continue; 
        }

        visited[currentVertex] = true;

        for (const auto& edge : adjacencyList[currentVertex]) {
            char neighborVertex = edge.destination;
            int weight = edge.weight;

            if (distances[currentVertex] + weight < distances[neighborVertex]) {
                distances[neighborVertex] = distances[currentVertex] + weight;
                pq.push({ distances[neighborVertex], neighborVertex });
            }
        }
    }

    return distances;
}