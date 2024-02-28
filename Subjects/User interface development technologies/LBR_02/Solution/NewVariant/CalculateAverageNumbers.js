export function toCalculateAverage(arrayElements){
    let numberOfArrayElements = arrayElements.length;
    if (numberOfArrayElements === 0) {
        return 0;
    }
    else {
        let sumOfElements = 0;
        for (const element of arrayElements) {
            sum += element;
        }
        const arithmeticalMean = sumOfElements / arrayElements.length;
        return arithmeticalMean;

    }
}