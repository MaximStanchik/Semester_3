#pragma once
#include "stdafx.h"

typedef struct icmp_echo_reply {
	IPAddr Address; // адрес ответившего узла
	ULONG Status; // статус ответа
	ULONG RoundTripTime; // время прохождения запроса в мс
	USHORT DataSize; // размер данных ответа
	USHORT Reserved; // зарезервировано
	PVOID Data; // указатель на данные ответа
	IP_OPTION_INFORMATION Options;
} ICMP_ECHO_REPLY, * PICMP_ECHO_REPLY;