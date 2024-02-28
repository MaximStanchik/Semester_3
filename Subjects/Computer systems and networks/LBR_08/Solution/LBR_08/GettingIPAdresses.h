#pragma once
#include "stdafx.h"

unsigned long getSubnetID(unsigned long IPAddress, unsigned long SubnetMask);
unsigned long getHostID(unsigned long IPAddress, unsigned long SubnetMask);
unsigned long getBroadcastAdress(unsigned long IPAddress, unsigned long SubnetMask);