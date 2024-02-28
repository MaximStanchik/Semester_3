window.getTheFirstRib = function (a) {
    return function getTheSecondRib(b) {
        return function getHeight(h) {
            return a * b * h;
        };
    };
};

window.isNumberValid = function (number) {
    return !isNaN(number) && number > 0;
};

window.GetTheValuesOfAllCreatedVariablesAndFunctions = function () {
    for (var property in window) {
        if (window.hasOwnProperty(property)) {
            var value = window[property];
            console.log(property + ':', value);
        }
    }
};

function Main() {
    alert("Началось выполнение второго задание.");

    const heightOfParallelepiped = parseFloat(prompt('Введите значение высоты (без ед. изм.) для прямоугольного параллелепипеда:'));
    const firstRibOfTheBaseOfParallelepiped = parseFloat(prompt('Введите значение ребра а основания (без ед. изм.) для прямоугольного параллелепипеда:'));
    const secondRibOfTheBaseOfParallelepiped = parseFloat(prompt('Введите значение ребра b (без ед. изм.) для прямоугольного параллелепипеда:'));

    if (isNumberValid(heightOfParallelepiped) && isNumberValid(firstRibOfTheBaseOfParallelepiped) && isNumberValid(secondRibOfTheBaseOfParallelepiped)) {
        const getTheSecondRib = getTheFirstRib(heightOfParallelepiped);
        const getHeight = getTheSecondRib(firstRibOfTheBaseOfParallelepiped);
        alert(getHeight(secondRibOfTheBaseOfParallelepiped));
    }
    else {
        alert("Введены некорректные значения. Автоматический переход к следующему заданию");
    }

    function* move() {
        var a;
        let x = 0;
        let y = 0;
        let direction;
    
        for (let i = 0; i < 10; i++) {
            direction = (a = prompt("Введите направление")) !== null && a !== undefined ? a : "default"; 
            switch (direction.trim().toLowerCase()) {
                case "left":
                    x--;
                    break;
                case "right":
                    x++;
                    break;
                case "up":
                    y++;
                    break;
                case "down":
                    y--;
                    break;
            }
            yield [x, y];
        }
    }
    
    let generator = move(); 
    
    for (let i = 0; i < 10; i++) {
        alert(generator.next().value);
    }

    window.GetTheValuesOfAllCreatedVariablesAndFunctions();
    alert("Значения всех созданных переменных и функции, которые хранятся в глобальном объекте window выведены в консоли разработчика");
}

Main();