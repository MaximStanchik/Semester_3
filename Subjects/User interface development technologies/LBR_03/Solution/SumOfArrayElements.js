export function toSumNestedArrayElements(array) {
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

export function toCreateNestedArray() {
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