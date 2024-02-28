.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
MB_OK EQU 0
ORIGNUMBERS DB "Сложили числа 3 и 5", 0
RESULT DB "Получили 8", 0
HW DD ?

.CODE

main PROC
START :
; Вывод окна с STR1
INVOKE MessageBoxA, HW, OFFSET ORIGNUMBERS, OFFSET ORIGNUMBERS, MB_OK

; Выполнение операции сложения
MOV eax, 3
ADD eax, 5

; Конвертация числа в строку
MOV ebx, OFFSET RESULT + 10
MOV ecx, 10
@LOOP:
XOR edx, edx
DIV ecx
ADD dl, 30h
DEC ebx
MOV BYTE PTR[ebx], dl
TEST eax, eax
JNZ @LOOP

; Вывод окна с STR3 и результатом сложения
INVOKE MessageBoxA, HW, OFFSET RESULT, OFFSET RESULT, MB_OK

push 0
call ExitProcess
main ENDP
end main