export function toCalculateTheSumOfCubesOfNumbers (amountOfNumbers) {
    let finalAmount = 0;

    for (let i = 1; i <= amountOfNumbers; i++) {
        finalAmount += Math.pow(i, 3);
      }

    return finalAmount;
}