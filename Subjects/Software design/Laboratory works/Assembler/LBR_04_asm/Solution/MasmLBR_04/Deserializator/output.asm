.586P
.MODEL FLAT, STDCALL
includelib kornel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
variable1 DWORD 20
variable0 DWORD 10
MB_OK	EQU 0
HW		DD ?
.CODE
main PROC

START: 
push 0
call ExitProcess
main ENDP
end main

