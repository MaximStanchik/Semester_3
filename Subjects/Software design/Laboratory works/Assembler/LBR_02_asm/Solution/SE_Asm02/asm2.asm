.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO: DWORD
MessageBoxA PROTO: DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
MB_OK EQU 0
ACTION DB "Действие:", 0
ORIGNUMBERS DB "Сложили числа 3 и 5", 0
COMPLETITION DB "Результат:", 0
RESULT DB "Получили ", 0
HW DD ?

.CODE

main PROC
START:
    ; Вывод окна с STR1
    INVOKE MessageBoxA, HW, OFFSET ORIGNUMBERS, OFFSET ACTION, MB_OK

    ; Выполнение операции сложения
    MOV eax, 3
    ADD eax, 5

    ; Конвертация числа в строку

    ADD eax, 30h
    mov [RESULT + 9], al
    ; Вывод окна с RESULT и результатом сложения
    INVOKE MessageBoxA, HW, OFFSET RESULT, OFFSET COMPLETITION, MB_OK

    push 0
    call ExitProcess
main ENDP
end main