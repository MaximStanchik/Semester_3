export function toCalculatePresentStudentsCount() {
    let presentStudents = [];
    let studentName = prompt("Введите имя студента (для завершения введите 'стоп'):");

    while (studentName !== "стоп") {
        if (studentName !== null && studentName !== "") {
            presentStudents.push(studentName);
        }
        studentName = prompt("Введите имя студента (для завершения введите 'стоп'):");
    }

    return presentStudents.length;
}