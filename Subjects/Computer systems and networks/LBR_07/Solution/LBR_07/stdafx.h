#pragma once

#include <iostream>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <iphlpapi.h>
#include <icmpapi.h>

#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "iphlpapi.lib")
#pragma comment(lib, "icmp.lib")

using namespace std;

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount);
