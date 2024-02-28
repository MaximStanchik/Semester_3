//первое задание:

const productsSet = new Set();

function addProductsToSet(numberOfProducts) {
    for (let i = 1; i <= numberOfProducts; i++) {
        productsSet.add(`Товар ${i}`);
    }
}

function removeProductFromSet(productName) {
    productsSet.delete(productName);
}

function checkProductExistence(productName) {
    return productsSet.has(productName);
}

function getProductCount() {
    return productsSet.size;
}

function NumberCheck(numberToCheck) {
    if (numberToCheck > 0 && typeof numberToCheck !== 'string' && Number.isInteger(numberToCheck)) {
        return true;
    } else {
        return false;
    }
}

//второе задание:

const studentsSet = new Set();

function removeStudentByRecordBookNumber(number) {
    studentsSet.forEach(student => {
        if (student.recordBookNumber === number) {
            studentsSet.delete(student);
        }
    });
}

function filterStudentsByGroup(group) {
    const filteredStudents = new Set();
    studentsSet.forEach(student => {
        if (student.group === group) {
            filteredStudents.add(student);
        }
    });
    return filteredStudents;
}

function sortStudentsByNumber() {
    const sortedStudents = Array.from(studentsSet);
    sortedStudents.sort((a, b) => a.recordBookNumber.localeCompare(b.recordBookNumber));
    return sortedStudents;
}

//третье задание:

const productsMap = new Map();

function addProduct(id, name, quantity, price) {
    if (productsMap.has(id)) {
        console.log('Товар с данным id уже существует.');
        return;
    }

    const product = {
        id: id,
        name: name,
        quantity: quantity,
        price: price
    };

    productsMap.set(id, product);
}

function removeProductById(id) {
    if (!productsMap.has(id)) {
        console.log('Товар с данным id не найден.');
        return;
    }

    productsMap.delete(id);
}

function removeProductsByName(name) {
    let count = 0;
    productsMap.forEach((product, id) => {
        if (product.name === name) {
            productsMap.delete(id);
            count++;
        }
    });

    if (count === 0) {
        console.log('Товары с данным названием не найдены.');
    }
}

function changeProductQuantity(id, newQuantity) {
    if (!productsMap.has(id)) {
        console.log('Товар с данным id не найден.');
        return;
    }

    const product = productsMap.get(id);
    product.quantity = newQuantity;
    productsMap.set(id, product);
}

function changeProductPrice(id, newPrice) {
    if (!productsMap.has(id)) {
        console.log('Товар с данным id не найден.');
        return;
    }

    const product = productsMap.get(id);
    product.price = newPrice;
    productsMap.set(id, product);
}

function calculateTotalProducts() {
    return productsMap.size;
}

function calculateTotalCost() {
    let totalCost = 0;
    productsMap.forEach(product => {
        const { quantity, price } = product;
        totalCost += quantity * price;
    });
    return totalCost;
}


//четвертое задание:

const cache = new WeakMap();

function Calculate(collection, key) {
    if (collection.has(key)) {
        return collection.get(key);
    }

    let resultOfFunction = 0;

    for (let i of key.Name) {
        resultOfFunction += i.charCodeAt();
    }
    resultOfFunction = key.group + '' + resultOfFunction;

    collection.set(key, resultOfFunction);

    return resultOfFunction;
}

function main() {
    const taskSelection = parseInt(
        prompt(
            'Выберите действие:\n' +
            '1. Перейти к заданию №1\n' +
            '2. Перейти к заданию №2\n' +
            '3. Перейти к заданию №3\n' +
            '4. Перейти к заданию №4\n' +
            '5. Выйти из программы'
        )
    );

    switch (taskSelection) {
        case 1: {
            const numberOfProducts = parseInt(prompt('Введите количество товаров, которые нужно добавить:'));
            addProductsToSet(numberOfProducts);
            const howManyProductsNeedToBeRemoved = parseInt(prompt('Введите количество товаров, которые нужно удалить:'));
            for (let i = 0; i < howManyProductsNeedToBeRemoved; i++) {
                const deleteSelection = prompt('Введите товар, который хотите удалить: (Товар + номер товара)');
                if (checkProductExistence(deleteSelection)) {
                    removeProductFromSet(deleteSelection);
                    alert(`Товар "${deleteSelection}" удален из списка.`);
                } else {
                    alert(`Товар "${deleteSelection}" не найден в списке.`);
                }
            }
            const productCount = getProductCount();
            alert(`Количество имеющихся товаров: ${productCount}`);

            break;
        }
        case 2: {
            alert("Результат выполнения второго задания представлен в консоли разработчика");
            const firstStudent = { recordBookNumber: '001', group: 'A', fullName: 'Иванов Иван Иванович' };
            const secondStudent = { recordBookNumber: '002', group: 'B', fullName: 'Петров Петр Петрович' };
            const thirdStudent = { recordBookNumber: '003', group: 'A', fullName: 'Сидорова Анна Павловна' };

            studentsSet.add(firstStudent);
            studentsSet.add(secondStudent);
            studentsSet.add(thirdStudent);

            const numberToRemove = '002';
            removeStudentByRecordBookNumber(numberToRemove);

            console.log(`Список студентов после удаления студента с номером зачетки ${numberToRemove}:`);
            studentsSet.forEach(student => {
                console.log(`Номер зачетки: ${student.recordBookNumber}, Группа: ${student.group}, ФИО: ${student.fullName}`);
            });

            const filteredGroup = 'A';
            const filteredStudents = filterStudentsByGroup(filteredGroup);

            console.log(`Список студентов в группе ${filteredGroup}:`);
            filteredStudents.forEach(student => {
                console.log(`Номер зачетки: ${student.recordBookNumber}, Группа: ${student.group}, ФИО: ${student.fullName}`);
            });

            const sortedStudents = sortStudentsByNumber();

            console.log('Список студентов после сортировки по номеру зачетки:');
            sortedStudents.forEach(student => {
                console.log(`Номер зачетки: ${student.recordBookNumber}, Группа: ${student.group}, ФИО: ${student.fullName}`);
            });
        }
        case 3: {
            addProduct(1, 'Товар 1', 5, 10);
            addProduct(2, 'Товар 2', 3, 15);
            addProduct(3, 'Товар 3', 2, 20);

            console.log('Количество товаров в списке:', calculateTotalProducts());
            console.log('Сумма стоимости всех товаров:', calculateTotalCost());

            removeProductById(2);

            console.log('Количество товаров в списке:', calculateTotalProducts());
            console.log('Сумма стоимости всех товаров:', calculateTotalCost());

            changeProductQuantity(1, 8);
            changeProductPrice(3, 25);

            console.log('Количество товаров в списке:', calculateTotalProducts());
            console.log('Сумма стоимости всех товаров:', calculateTotalCost());

            removeProductsByName('Товар 3');

            console.log('Количество товаров в списке:', calculateTotalProducts());
            console.log('Сумма стоимости всех товаров:', calculateTotalCost());
            break;
        }
        case 4: {
            let stu1 = { Name: "Jone", group: 7 };
            let stu2 = { Name: "Mila", group: 3 };
            let stu3 = { Name: "Max", group: 11 };

            alert("6 идентификаторов 4-го задания:");
            alert("ID: " + Calculate(cache, stu1));
            alert("ID: " + Calculate(cache, stu2));
            alert("ID: " + Calculate(cache, stu3));
            alert("ID: " + Calculate(cache, stu1));
            alert("ID: " + Calculate(cache, stu2));
            alert("ID: " + Calculate(cache, stu3));

            break;
        }
        case 5: {
            alert("Программа закончила свое выполнение");
            break;
        }
        default: {
            alert("Вы ввели неправильное значение. Автоматический выход из программы.");
            break;
        }
    }
}

main();
