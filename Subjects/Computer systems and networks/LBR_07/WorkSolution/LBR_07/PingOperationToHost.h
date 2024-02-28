#include "stdafx.h"

#ifndef PINGOPERATIONTOHOST
#define PINGOPERATIONTOHOST

#include <iostream>
#include <winsock2.h>
#include <icmpapi.h>

#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "iphlpapi.lib")

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount);

#endif 
