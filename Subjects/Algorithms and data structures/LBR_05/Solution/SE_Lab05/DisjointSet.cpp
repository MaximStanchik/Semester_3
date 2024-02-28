#include "DisjointSet.h"

void DisjointSet::makeSet(std::string vertex) {
    parent[vertex] = vertex;
    rank[vertex] = 0;
}

std::string DisjointSet::findSet(std::string vertex) {
    if (parent[vertex] != vertex) {
        parent[vertex] = findSet(parent[vertex]);
    }
    return parent[vertex];
}

void DisjointSet::unionSets(std::string vertex1, std::string vertex2) {
    std::string root1 = findSet(vertex1);
    std::string root2 = findSet(vertex2);

    if (root1 != root2) {
        if (rank[root1] < rank[root2]) {
            parent[root1] = root2;
        }
        else if (rank[root1] > rank[root2]) {
            parent[root2] = root1;
        }
        else {
            parent[root1] = root2;
            rank[root2]++;
        }
    }
}