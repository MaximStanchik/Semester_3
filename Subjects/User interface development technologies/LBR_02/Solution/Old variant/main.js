import { calculateCircleProperties } from './Circle.js';
import { toInformAboutOrderAcceptance } from './Order.js';
import { toCombineParameters } from './ConcatenationOfStrings.js';
import { toCalculatePresentStudentsCount } from './Students.js';
import { toConcatenateParameters } from './ConcatenationOfStrings(arrow function).js';
import { toCalculateThePerimeterOfASquareOrAreaOfARectangle } from './CalculateThePerimeterOfASquar.js';
import { toCalculateTheTimeToGuessThePassword } from './Password.js';

function main() {
    const radiusOfCircle = prompt("Введите радиус круга (значение в метрах без букв):");

    if (isNaN(radiusOfCircle)) {
        alert("Ошибка: Введено некорректное значение радиуса");
        return;
    }

    const parsedRadius = parseFloat(radiusOfCircle);
    const circleProperties = calculateCircleProperties(parsedRadius);

    console.log("Площадь круга: " + circleProperties.area);
    console.log("Диаметр круга: " + circleProperties.diameter);
    console.log("Длина окружности круга: " + circleProperties.circumference);

    const amountOfFunds = prompt("Введите количество денежных средств на Вашей карте:");
    const costOfGood = prompt("Введите стоимость товара (для прекращения введите 'стоп'):");

    if (isNaN(costOfGood)) {
        alert("Ошибка: Введено некорректное значение стоимости товара");
        return;
    }

    const parsedAmountOfFunds = parseFloat(amountOfFunds);

    if (isNaN(parsedAmountOfFunds)) {
        alert("Ошибка: Введено некорректное значение количества денежных средств");
        return;
    }

    if (toInformAboutOrderAcceptance(parsedAmountOfFunds, parsedCostOfGood) === 1) {
        alert("Извините, у Вас недостаточно средств на банковском счёте.");

        const userInput = prompt("Введите данные:\n" +
            "0 -- завершить покупку без учета последнего товара\n" +
            "1 -- выбрать товар с наименьшей стоимостью, которая не превышает остаток на карте\n" +
            "Любая другая клавиша -- отмена"
        );

        switch (userInput) {
            case '0':
                alert("Общая стоимость покупки составит: " + toInformAboutOrderAcceptance(parsedAmountOfFunds, parsedCostOfGood));
                break;
            case '1':
                const goodSerialNumber = prompt("Пожалуйста, введите порядковый номер товара, который Вы выбрали:");

                if (isNaN(goodSerialNumber) || goodSerialNumber < 1) {
                    alert("Ошибка: Введено некорректное значение порядкового номера товара");
                } else {
                    alert("Общая стоимость покупки составит: " + toInformAboutOrderAcceptance(parsedAmountOfFunds, parsedCostOfGood, goodSerialNumber));
                }
                break;
            default:
                break;
        }
    }

    const param3 = prompt("Введите третий параметр:");

    if (param3 === null || param3 === "") {
        alert("Ошибка! Вы не ввели третий параметр.");
        return;
    }

    alert(toCombineParameters(param3));
    alert(toConcatenateParameters(param3));

    alert("Количество студентов: " + toCalculatePresentStudentsCount());

    const a = prompt("Введите стоорону а:");
    const b = prompt("Введите сторону b:");

    const toCalculateThePerimeterOfASquareOrAreaOfARectangle_function_expression = function (a, b) {
        if (a === b) {
            return 4 * a;
        } else {
            return a * b;
        }
    };

    alert("Используем функцию для вычисления периметра, если фигура--квадрат, площади, если фигура--прямоугольник" + toCalculateThePerimeterOfASquareOrAreaOfARectangles(a, b));
    alert("Используем функциональное выражение для вычисления периметра, если фигура--квадрат, площади, если фигура--прямоугольник" + toCalculateThePerimeterOfASquareOrAreaOfARectangle_function_expression(a, b));

    console.log(toCalculateTheTimeToGuessThePassword());
}

main();