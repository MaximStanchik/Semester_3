function toCreateAPyramidTower(numberOfFloorsOfTheTower) {
    const pyramid = [];
    const maxWidth = 2 * numberOfFloorsOfTheTower - 1;

    for (let i = 0; i < numberOfFloorsOfTheTower; i++) {
        const currentFloorWidth = 2 * i + 1;
        const padding = (maxWidth - currentFloorWidth) / 2;
        const floor = ' '.repeat(padding) + '*'.repeat(currentFloorWidth) + ' '.repeat(padding);
        pyramid.push(floor);
    }

    return pyramid.join('\n');
}

function newObj(...obj) {
    let result = {};
    
    Object.assign(result, ...obj);

    return result;
}


function toExtend(...objects) {
    return Object.assign({}, ...objects);
  }

function toCalculateTotals(inputString) {
    let total1 = 0;
    let total2 = 0;
  
    for (let i = 0; i < inputString.length; i++) {
      const charCode = inputString.charCodeAt(i);
      total1 += charCode;
  
      if (charCode[i] === '7') {
        total2 += 1;
      }
    }
  
    const result = total1 - total2;
    return result;
  }

function toSumNestedArrayElements(array) {
    let sum = 0;

    for (let i = 0; i < array.length; i++) {
        const element = array[i];

        if (Array.isArray(element)) {
            sum += toSumNestedArrayElements(element);
        } else {
            sum += element;
        }
    }

    return sum;
}

function toCreateNestedArray() {
    const array = [];

    while (true) {
        const userInput = prompt('Введите элемент массива (или "Выход" для завершения):');

        if (userInput === 'Выход') {
            break;
        }

        const element = parseFloat(userInput);

        if (!isNaN(element)) {
            array.push(element);
        }
    }

    return array;
}

function toFilterStudentsByGroup(students) {
    const result = {};
  
    for (let i = 0; i < students.length; i++) {
      const student = students[i];
  
      if (student.age > 17) {
        const groupId = student.groupId;
  
        if (!result[groupId]) {
          result[groupId] = [];
        }
  
        result[groupId].push(student);
      }
    }
  
    return result;
  }

function toValidateInput(input) {
    if (/^\d+$/.test(input)) {
      return parseInt(input, 10);
    }
    return null;
  }

function toReduseArrays (Array_1, Array_2) {
    const combinedArray = Array_2.reduce((result, currentElement) => {
        return result.concat([currentElement]);
      }, Array_1);
}


function toExBox(start, cur) {
    if (Array.isArray(cur))
        cur.reduce(toExBox, start);
    else
        start.push(cur);

    return start;
}

    let mass = [1, [1, 2, [3, 4]], [2, 4]];
    var sMass = [];

    sMass = mass.reduce(toExBox, []);

    alert('Результат выполнения первого задания: ' + sMass);

    const nestedArray = toCreateNestedArray();
    const sum = toSumNestedArrayElements(nestedArray);
    alert('Результат выполнения второго задания:' + sum);

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
    alert('Результат выполнения третьего заданния представлен в консоли разработчика');
    console.log('Результат:', filteredStudents);


const inputString = prompt('Введите строку для четвертого задания:');
const result = toCalculateTotals(inputString);
console.log('Результат выполнения четвертого задания:', result);

let objekt = [
    {
        a: 1,
        b: 2
    },
    {
        //b: 3,
        c: 3
    }];

objekt[2] = newObj(objekt[0], objekt[1]);
console.log(objekt[2].a + ' ' + objekt[2].b + ' ' + objekt[2].c)

const numberOfFloorsOfTheTower = prompt("Введите количество этажей башни, чтобы построить её")
if (!isNaN(numberOfFloorsOfTheTower)) {
    alert("Вот Ваша башня: " + toCreateAPyramidTower(numberOfFloorsOfTheTower));
}
else {
    alert("Значение, которое Вы ввели, не является числом");
}
