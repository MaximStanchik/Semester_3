#include <cstddef>
#include <cstdlib>
#include <iostream>
#include <set>
#include <stdlib.h>
#include <time.h>
#include <vector>
#include <algorithm>

using namespace std;

const int MATRIX[8][8] = {
    {0,  25, 40, 31, 27, 34, 22, 4},
    {5,  0,  17, 30, 25, 12, 45, 1},
    {19, 15, 0,  6,  1,  82, 1,  21},
    {9,  50, 24, 0,  6,  12, 4,  5},
    {22, 8,  7,  10, 0,  7,  3,  1},
    {22, 8,  7,  10, 2,  0,  3,  1},
    {22, 8,  7,  10, 3,  7,  0,  1},
    {12, 6,  21, 21, 21, 4,  2,  0}
};

struct Pop {
    vector<int> Population;
    size_t cost;
};

void stock_population(vector<Pop>& population, int size);
void evolute(vector<Pop>& populations, int size, int stock_size);
vector<Pop> crossover(Pop p1, Pop p2);
Pop mutate(const Pop);
void calcCost(Pop&);

int main() {
    setlocale(LC_ALL, "Rus");
    srand(time(NULL));
    short stock_size_of_population, num_of_evolutions;
    vector<Pop> vector_of_populations;
    cout << "Введите численность популяции: ";
    cin >> stock_size_of_population;
    cout << "\nВведите число эволюций: ";
    cin >> num_of_evolutions;

    stock_population(vector_of_populations, stock_size_of_population);
    for (auto pop : vector_of_populations) {
        cout << endl << pop.cost << " : ";
        for (auto node : pop.Population) {
            cout << node << ' ';
        }
    }
    evolute(vector_of_populations, num_of_evolutions, stock_size_of_population);

    Pop min_path = vector_of_populations.front();

    cout << "\nМинимальный путь: ";
    for (auto path : min_path.Population) {
        cout << path << ' ';
    }
    cout << endl << "Затраты: " << min_path.cost;
    return 0;
}

void stock_population(vector<Pop>& populations, int size) {
    while (populations.size() < size) {
        vector<int> path{};
        size_t cost = 0;
        while (path.size() < 8) {
            bool found = 0;
            int num = rand() % 8;
            for (auto node : path) {
                if (node == num)
                    found = true;
            }
            if (!found) {
                if (!path.empty())
                    cost += MATRIX[path.back()][num];
                path.push_back(num);
            }
        }
        cost += MATRIX[path[0]][path[7]];
        Pop population = { path, cost };
        populations.push_back(population);
    }
}

void evolute(vector<Pop>& populations, int size, int stock_size) {
    for (int j = 0; j < size; j++) {
        cout << endl << "-------- " << j << " ----------" << endl;
        int rand1, rand2;
        do {
            rand1 = rand() % populations.size();
            rand2 = rand() % populations.size();
        } while (rand1 == rand2);
        Pop parent1 = populations[rand1];
        Pop parent2 = populations[rand2];
        vector<Pop> newPops = crossover(parent1, parent2);
        for (auto child : newPops)
            populations.push_back(child);
        sort(populations.begin(), populations.end(),
            [](Pop const& a, Pop const& b) {
                return a.cost < b.cost;
            });
        for (auto pop : populations) {
            cout << endl << pop.cost << " : ";
            for (auto node : pop.Population) {
                cout << node << ' ';
            }
        }
        while (populations.size() != stock_size)
            populations.pop_back();
    }
}

vector<Pop> crossover(Pop p1, Pop p2) {
    set<int> Variants1 = { 0, 1, 2, 3, 4, 5, 6, 7 };
    set<int> Variants2 = Variants1;
    Pop np1{ {},0 }, np2{ {},0 };
    int crossover_point = rand() % 7 + 1;
    for (int i = 0; i < crossover_point; i++) {
        Variants1.erase(p1.Population[i]);
        Variants2.erase(p2.Population[i]);
        np1.Population.push_back(p1.Population[i]);
        np2.Population.push_back(p2.Population[i]);
    }
    for (int i = crossover_point; i < p1.Population.size(); i++) {
        if (!Variants1.empty() && Variants1.find(p2.Population[i]) != Variants1.end()) {
            np1.Population.push_back(p2.Population[i]);
            Variants1.erase(p2.Population[i]);
        }
    }
    for (int i = crossover_point; i < p2.Population.size(); i++) {
        if (Variants2.find(p1.Population[i]) != Variants2.end()) {
            np2.Population.push_back(p1.Population[i]);
            Variants2.erase(p1.Population[i]);
        }
    }
    if (!Variants1.empty())
        for (auto node : Variants1)
            np1.Population.push_back(node);
    if (!Variants2.empty())
        for (auto node : Variants2)
            np2.Population.push_back(node);
    calcCost(np1);
    calcCost(np2);
    vector<Pop> newPop = { np1,np2 };
    int size = newPop.size();
    for (int i = 0; i < size; i++) {
        if (rand() % 100 > 50)
            newPop.push_back(mutate(newPop[i]));
    }
    return newPop;
}

Pop mutate(const Pop old) {
    Pop child = old;
    child.cost = 0;
    int x, y;
    do {
        x = rand() % 8;
        y = rand() % 8;
    } while (x == y);
    swap(child.Population[x], child.Population[y]);
    calcCost(child);
    return child;
}

void calcCost(Pop& p) {
    for (int i = 0; i < p.Population.size() - 1; i++) {
        int from = p.Population[i];
        int to = p.Population[i + 1];
        p.cost += MATRIX[from][to];
    }
    p.cost += MATRIX[p.Population.back()][p.Population.front()];
}
