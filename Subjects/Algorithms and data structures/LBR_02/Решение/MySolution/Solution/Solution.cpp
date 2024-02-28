#include <iostream>
#include <vector>
#include <queue>
#include <stack>

using namespace std;


// Структура для представления ребра графа
struct Edge {
    int source;
    int destination;

    Edge(int src, int dest) : source(src), destination(dest) {}
};

// Класс для представления графа
class Graph {
public:
    int numVertices;
    vector<Edge> edgeList;
    vector<vector<int>> adjacencyMatrix;
    vector<vector<int>> adjacencyList;

    // Конструктор для задания числа вершин в графе
    Graph(int vertices) : numVertices(vertices) {
        adjacencyMatrix.resize(vertices, vector<int>(vertices, 0));
        adjacencyList.resize(vertices);
    }

    // Добавление ребра в граф
    void addEdge(int src, int dest) {
        edgeList.push_back(Edge(src, dest));
        adjacencyMatrix[src][dest] = 1;
        adjacencyMatrix[dest][src] = 1;
        adjacencyList[src].push_back(dest);
        adjacencyList[dest].push_back(src);
    }

    // Вывод списка ребер
    void printEdgeList() {
        cout << "Список ребер:" << endl;
        for (const Edge& edge : edgeList) {
            cout << edge.source + 1 << " - " << edge.destination + 1 << endl;
        }
    }

    // Вывод матрицы смежности
    void printAdjacencyMatrix() {
        cout << "Матрица смежности:" << endl;
        for (int i = 0; i < numVertices; i++) {
            for (int j = 0; j < numVertices; j++) {
                cout << adjacencyMatrix[i][j] << " ";
            }
            cout << endl;
        }
    }

    // Вывод списка смежности
    void printAdjacencyList() {
        cout << "Список смежности:" << endl;
        for (int i = 0; i < numVertices; i++) {
            cout << i + 1 << " - ";
            for (int neighbor : adjacencyList[i]) {
                cout << neighbor + 1 << " ";
            }
            cout << endl;
        }
    }
};

// Алгоритм поиска в ширину
void BFS(const Graph& graph, int startVertex) {
    vector<bool> visited(graph.numVertices, false);
    queue<int> q;

    visited[startVertex] = true;
    q.push(startVertex);

    cout << "Порядок прохождения вершин в BFS: ";
    while (!q.empty()) {
        int currentVertex = q.front();
        q.pop();
        cout << currentVertex + 1 << " ";

        for (int neighbor : graph.adjacencyList[currentVertex]) {
            if (!visited[neighbor]) {
                visited[neighbor] = true;
                q.push(neighbor);
            }
        }
    }
    cout << endl;
}

// Алгоритм поиска в глубину
void DFS(const Graph& graph, int startVertex, vector<bool>& visited) {
    cout << startVertex + 1 << " ";
    visited[startVertex] = true;

    for (int neighbor : graph.adjacencyList[startVertex]) {
        if (!visited[neighbor]) {
            DFS(graph, neighbor, visited);
        }
    }
}

int main() {
    setlocale(LC_CTYPE, "Russian");
    int numVertices = 10;
    Graph graph(numVertices);

    graph.addEdge(0, 1);
    graph.addEdge(0, 4);
    graph.addEdge(1, 6);
    graph.addEdge(1, 7);
    graph.addEdge(2, 7);
    graph.addEdge(3, 5);
    graph.addEdge(3, 8);
    graph.addEdge(4, 5);
    graph.addEdge(5, 8);
    graph.addEdge(6, 7);
    graph.addEdge(8, 9);

    int startVertex;
    cout << "Введите начальную вершину для обхода: ";
    cin >> startVertex;

    graph.printEdgeList();

    graph.printAdjacencyMatrix();

    graph.printAdjacencyList();

    BFS(graph, startVertex - 1);

    vector<bool> visited(numVertices, false);
    cout << "Порядок прохождения вершин в DFS: ";
    DFS(graph, startVertex - 1, visited);
    cout << endl;

    return 0;
}