function main() {
    //-----------Task_2---------------//

    var bigSide = 41;
    var smallSide = 21;
    var areaOfaQuadrilateral = bigSide * smallSide;
    console.log("Ответ: площадь четырёхугольника A равна " + areaOfaQuadrilateral + "мм^2");

    //-----------Task_3---------------//

    var squareArea = 5 * 5;
    console.log("Ответ: в четырёхугольник А поместится следующее количество квадратов В: " + Math.floor(areaOfaQuadrilateral / squareArea));

    //-----------Task_5---------------//

    const str1: string = "Котик";
    var smallLetterCat: string = "котик";

    var Hello = "Привет";
    var Bye = "Пока";

    var number_1 = 73;
    var number_2 = 53;

    var falseWithWords = false;
    var falseWithNull = 0;

    var number_3 = 54;
    var trueWithWords = true;

    var number_4 = 123;
    var falseWithWords = false;

    var trueWithWords = true;
    var positiveNumberButItIsString_1 = "3";

    var number_5 =3;
    var length = "5мм";

    var number_6 = 8;
    var negativeNumberButItIsString = "-2";

    var number_7 = 34;
    var positiveNumberButItIsString_2 = "34";

    null;
    undefined;

    //-----------Task_6---------------//

    function checkUserName(userName: string): void {
      const teacherName = "Иван Иванович";

      const formattedUserName = userName.toLowerCase();
      const formattedTeacherName = teacherName.toLowerCase();

      if (formattedUserName === formattedTeacherName) {
        console.log("Введенные данные верные.");
      } else {
        console.log("Введенные данные неверные.");
      }
    }
    
    const userInput_6 = prompt("Введите ваше имя:");

    if (userInput_6) {
      checkUserName(userInput_6);
    } else {
      console.log("Имя не было введено.");
    }

    //-----------Task_7---------------//

    function checkExamsPassed(russian: boolean, math: boolean, english: boolean): string {
      if (russian && math && english) {
        return "Студент переведен на следующий курс.";
      } else if (!russian && !math && !english) {
        return "Студент отчислен.";
      } else {
        return "Студент ожидает пересдачу.";
      }
    }

    const russianPassed = confirm("Студент сдал экзамен по русскому языку?");
    const mathPassed = confirm("Студент сдал экзамен по математике?");
    const englishPassed = confirm("Студент сдал экзамен по английскому языку?");

    const result = checkExamsPassed(russianPassed, mathPassed, englishPassed);
    console.log(result);
    
    //-----------Task_8---------------//

    function calculate(a: number, b: number, n: number): void {
      const sum = a + b;
      const difference = a - b;
      const division = a / b;
      const multiplication = a * b;
      const exponentiation = Math.pow(a, n);
      const remainder = a % b;
      const squareRootA = Math.sqrt(a);
      const squareRootB = Math.sqrt(b);
    
      console.log(`Сумма: ${sum}`);
      console.log(`Разница: ${difference}`);
      console.log(`Деление: ${division}`);
      console.log(`Умножение: ${multiplication}`);
      console.log(`Возведение в степень ${n}: ${exponentiation}`);
      console.log(`Остаток от деления: ${remainder}`);
      console.log(`Корень числа a: ${squareRootA}`);
      console.log(`Корень числа b: ${squareRootB}`);
    }
    
    const numberA = parseFloat(prompt("Введите число a:")!);
    const numberB = parseFloat(prompt("Введите число b:")!);
    const exponent = parseInt(prompt("Введите степень n:")!);
    
    if (!isNaN(numberA) && !isNaN(numberB) && !isNaN(exponent)) {
      calculate(numberA, numberB, exponent);
    } else {
      console.log("Некорректный ввод чисел или степени.");
    }

     //-----------Task_10---------------//

    for (let i = 1; i <= 10; i++) {
      if (i % 2 === 0) {
        console.log(i + 2);
      } else {
        console.log(`${i}мм`);
      }
    }

    //-----------Task_11(Реализация через объект)---------------//

const daysOfWeek_Object: { [key: number]: string } = {
  1: 'пн',
  2: 'вт',
  3: 'ср',
  4: 'чт',
  5: 'пт',
  6: 'сб',
  7: 'вс',
};

let userInput_11: string | null;
let input_11: number;

do {
  userInput_11 = prompt("Введите номер дня недели (от 1 до 7):");

  if (userInput_11 === null) {
    break;
  }

  input_11 = parseInt(userInput_11);

  if (!isNaN(input_11) && input_11 >= 1 && input_11 <= 7) {
    const dayOfWeek = daysOfWeek_Object[input_11];
    console.log(`День недели: ${dayOfWeek}`);
  } else {
    alert("Некорректный ввод. Пожалуйста, введите число от 1 до 7.");
  }
} while (userInput_11 !== null);

//-----------Task_11(Реализация через массив)---------------//

const daysOfWeek_Array: string[] = [
  'пн',
  'вт',
  'ср',
  'чт',
  'пт',
  'сб',
  'вс',
];

let userInput: string | null;
let input: number;

do {
  userInput = prompt("Введите номер дня недели (от 1 до 7):");

  if (userInput === null) {
    break;
  }

  input = parseInt(userInput);

  if (!isNaN(input) && input >= 1 && input <= 7) {
    const dayOfWeek = daysOfWeek_Array[input - 1];
    console.log(`День недели: ${dayOfWeek}`);
  } else {
    alert("Некорректный ввод. Пожалуйста, введите число от 1 до 7.");
  }
} while (userInput !== null);
}


