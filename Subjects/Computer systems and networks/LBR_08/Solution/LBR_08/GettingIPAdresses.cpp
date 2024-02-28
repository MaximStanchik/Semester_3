#include "stdafx.h"

unsigned long getSubnetID(unsigned long IPAddress, unsigned long SubnetMask) {
	unsigned long SubnetID = IPAddress & SubnetMask;
	return SubnetID;
}

unsigned long getHostID(unsigned long IPAddress, unsigned long SubnetMask) {
	unsigned long HostID = IPAddress & ~SubnetMask;
	return HostID;
}

unsigned long getBroadcastAdress(unsigned long IPAddress, unsigned long SubnetMask) {
	unsigned long broadcastAdress = IPAddress | ~SubnetMask;
	return broadcastAdress;
}