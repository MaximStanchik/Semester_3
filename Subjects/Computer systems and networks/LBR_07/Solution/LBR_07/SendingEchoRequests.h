#include "stdafx.h"

DWORD IcmpSendEcho
(
	__in HANDLE IcmpHandle, //дискриптор полученный функцией IcmpCreateFile
	__in IPAddr DestinationAddress, //IP адрес запроса
	__in LPVOID RequestData, //указатель на буфер эхо-запроса
	__in WORD RequestSize, //размер буфера эхо-запроса
	__in PIP_OPTION_INFORMATION RequestOptions, //указатель на структуру с опциями запроса
	__inout LPVOID ReplyBuffer, //указатель на буфер эхо-ответа
	__in DWORD ReplySize, //размер буфера эхо-ответа
	__in DWORD Timeout //таймаут в миллисекундах
);