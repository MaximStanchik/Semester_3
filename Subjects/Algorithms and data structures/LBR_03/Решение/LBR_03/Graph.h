#pragma once
#include <vector>
#include <queue>
#include <unordered_map>
#include <climits> 

struct Edge {
    char destination;
    int weight;
};

class Graph {
private:
    std::unordered_map<char, std::vector<Edge>> adjacencyList;

public:
    void addEdge(char source, char destination, int weight);
    void printGraph();
    std::unordered_map<char, int> dijkstra(char startVertex);
};
