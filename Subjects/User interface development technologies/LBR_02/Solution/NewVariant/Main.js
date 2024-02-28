function basicOperation (operation, operand1, operand2) {
  switch (operation) {
      case '+':
        result = operand1 + operand2;
        break;
      case '-':
        result = operand1 - operand2;
        break;
      case '*':
        result = operand1 * operand2;
        break;
      case '/':
        result = operand1 / operand2;
        break;
      default:
        result = 1;
        break;
    }
  return result;
}

function toCalculateTheSumOfCubesOfNumbers(amountOfNumbers) {
  let finalAmount = 0;
  for (let i = 1; i <= amountOfNumbers; i++) {
    finalAmount += Math.pow(i, 3);
  }
  return finalAmount;
}

function toCalculateAverage(arrayElements) {
  let numberOfArrayElements = arrayElements.length;
  if (numberOfArrayElements === 0) {
    return 0;
  } else {
    let sumOfElements = 0;
    for (const element of arrayElements) {
      sumOfElements += element;
    }
    const arithmeticalMean = sumOfElements / arrayElements.length;
    return arithmeticalMean;
  }
}

function toReverseAndFilter(str) {
  const reversed = str.split('').reverse().join('');
  const filtered = reversed.replace(/[^a-zA-Z]/g, '');
  return filtered;
}

function toRepeatString(s, n) {
  let repeatedString = '';
  if (!isNaN(n) && Number.isInteger(n) && n > 0) {
    for (let i = 0; i < n; i++) {
      repeatedString += s;
    }
    return repeatedString;
  } else {
    return 'Ошибка! Число должно быть положительным целым числом.';
  }
}

function toGetUniqueStrings(array1, array2) {
  const array3 = [];
  for (let i = 0; i < array1.length; i++) {
    if (!array2.includes(array1[i])) {
      array3.push(array1[i]);
    }
  }
  return array3;
}

const operation = prompt("Введите операцию:");
const operator1 = Number(prompt("Введите первое число:"));
const operator2 = Number(prompt("Введите второе число:"));

if (!isNaN(operator1) && !isNaN(operator2)) {
  if (basicOperation(operation, operator1, operator2) === 1) {
    alert("Извините, Вы неправильно ввели оператор");
  } else {
    alert("Результат вычисления введенного вами выражения: " + basicOperation(operation, operator1, operator2));
  }
} else {
  alert("Извините, Вы неправильно ввели значения для переменных");
}

const amountOfNumbers = Number(prompt("Введите количество чисел, сумму кубов которых Вы хотите найти:"));
if (!isNaN(amountOfNumbers)) {
  alert("Сумма кубов всех чисел: " + toCalculateTheSumOfCubesOfNumbers(amountOfNumbers));
} else {
  alert("Извините, Вы неправильно ввели число");
}

const str1 = prompt("Введите первую строку:");
const str2 = prompt("Введите вторую строку:");
alert("Результат преобразования первой строки: " + toReverseAndFilter(str1));
alert("Результат преобразования второй строки: " + toReverseAndFilter(str2));

const input = prompt("Введите элементы массива через запятую:");
const separatedElements = input.split(",");
const arrayElements = [];

for (let i = 0; i < separatedElements.length; i++) {
  const element = Number(separatedElements[i].trim());
  if (!isNaN(element)) {
    arrayElements.push(element);
  }
}
alert("Среднее арифметическое: " + toCalculateAverage(arrayElements));

const inputString = prompt("Введите строку:");
const inputIntNumber = parseInt(prompt("Введите целое число:"));

if (!isNaN(inputIntNumber) && Number.isInteger(inputIntNumber) && inputIntNumber > 0) {
  alert("Результат выполнения функции 'toRepeatString': " + toRepeatString(inputString, inputIntNumber));
} else if (!isNaN(inputIntNumber) && Number.isInteger(inputIntNumber) && inputIntNumber < 0) {
  alert("Ошибка! Число меньше единицы.");
} else {
  alert("Ивините, Вы неправильно ввели число");
}

const array1 = ['apple', 'banana', 'orange', 'kiwi'];
const array2 = ['banana', 'kiwi', 'grape'];

alert("Результат выполнения функции для 6-ого задания: " + toGetUniqueStrings(array1, array2));