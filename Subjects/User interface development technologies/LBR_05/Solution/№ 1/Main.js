function makeCounter1() {
    let currentCount = 1;

    return function() {
        return currentCount++;
    }
}

let counter1 = makeCounter1();

console.log ("Результат выполнения Варианта 1:");

console.log ( counter1() );
console.log ( counter1() );
console.log ( counter1() );

let counter12 = makeCounter1();
console.log( counter12() );


////////

let currentCount = 1;

function makeCounter2() {
    return function() {
        return currentCount++;
    };
}

let counter2 = makeCounter2();
let counter22 = makeCounter2();

console.log ("Результат выполнения Варианта 2:");

console.log( counter2() );
console.log( counter2() );

console.log( counter22());
console.log( counter22());