#include "Graph.h"
#include <iostream>

vector<vector<float>> Graph::D0Matrix() {
    std::vector<std::vector<float>> D0 = {
        {0,  28,       21,       59,       12, 27     },
        {7,  0,        24,       INFINITY, 21, 9      },
        {9,  32,       0,        13,       11, INFINITY},
        {8,  INFINITY, 5,        0,        16, INFINITY},
        {14, 13,       15,       10,       0,  22     },
        {15, 18,       INFINITY, INFINITY, 6,  0      }
    };
    return D0;
}

vector<vector<float>> Graph::S0Matrix() {
    std::vector<std::vector<float>> S0 = {
        {0, 2, 3, 4, 5, 6},
        {1, 0, 3, 4, 5, 6},
        {1, 2, 0, 4, 5, 6},
        {1, 2, 3, 0, 5, 6},
        {1, 2, 3, 4, 0, 6},
        {1, 2, 3, 4, 5, 0}
    };
    return S0;
}

void Graph::printMatrix(const vector<vector<float>>& matrix) {
    for (const auto& row : matrix) {
        for (const auto& value : row) {
            cout << value << " ";
        }
        cout << endl;
    }
}

void Graph::floydWarshall(vector<vector<float>>& matrix, vector<vector<float>>& intermediateVertex) {
    for (float i = 0; i < matrix.size(); i++)
    {
        for (float j = 0; j < matrix.size(); j++)
        {
            if (j == i || matrix[j][i] == INFINITY)
                continue;

            for (float y = 0; y < matrix.size(); y++)
            {
                if (j == y || y == i || matrix[i][y] == INFINITY)
                    continue;

                if (matrix[j][y] > (matrix[j][i] + matrix[i][y]))
                {
                    matrix[j][y] = matrix[j][i] + matrix[i][y];
                    intermediateVertex[j][y]=i+1;
                }
            }
        }
    } 
}




