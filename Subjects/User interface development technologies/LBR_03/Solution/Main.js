import { toCreateAPyramidTower } from './PyramidTower.js';
import { toCalculateTotals } from './TotalsCalculation.js';
import { toExtend } from './Union.js';
import { toSumNestedArrayElements } from './SumOfArrayElements.js';
import { toCreateNestedArray } from './SumOfArrayElements.js';
import { toFilterStudentsByGroup } from './StudentsInfo.js';
import { toValidateInput } from './StudentsInfo.js';
import { toExBox } from './ExBox.js';

function main() {
    let mass = [1, [1, 2, [3, 4]], [2, 4]];
    var sMass = [];

    sMass = mass.reduce(toExBox, []);

    console.log(sMass);

    const nestedArray = toCreateNestedArray();
    const sum = toSumNestedArrayElements(nestedArray);
    console.log('Сумма элементов массива:', sum);

    const students = [];

    while (true) {
        const name = prompt('Введите имя студента (или "Выход" для завершения):');
        if (name === 'Выход') {
            break;
        }

        let age;
        while (true) {
            const ageInput = prompt('Введите возраст студента:');
            age = toValidateInput(ageInput);
            if (age !== null) {
                break;
            }
            alert('Некорректный ввод возраста. Пожалуйста, введите положительное число без букв.');
        }

        let groupId;
        while (true) {
            const groupIdInput = prompt('Введите номер группы студента:');
            groupId = toValidateInput(groupIdInput);
            if (groupId !== null) {
                break;
            }
            alert('Некорректный ввод номера группы. Пожалуйста, введите целочисленное положительное число.');
        }

        const student = {
            name: name,
            age: age,
            groupId: groupId
        };

        students.push(student);
    }

    const filteredStudents = toFilterStudentsByGroup(students);
    console.log('Результат:', filteredStudents);
}

const inputString = prompt('Введите строку:');
const result = toCalculateTotals(inputString);
console.log('Результат:', result);

const objects = [];

while (true) {
    const varName = prompt('Введите название переменной (или "Выход" для завершения):');
    if (varName === 'Выход') {
        break;
    }

    const varValue = prompt('Введите значение переменной:');

    const variable = { [varName]: eval(varValue) };

    objects.push(variable);
}

const resultOfExtension = toExtend(...objects);
console.log('Результат:', resultOfExtension);

const numberOfFloorsOfTheTower = prompt("Введите количество этажей башни, чтобы построить её")
if (!isNaN(numberOfFloorsOfTheTower)) {
    alert("Вот Ваша башня: " + toCreateAPyramidTower(numberOfFloorsOfTheTower));
}
else {
    alert("Значение, которое Вы ввели, не является числом");
}
main();