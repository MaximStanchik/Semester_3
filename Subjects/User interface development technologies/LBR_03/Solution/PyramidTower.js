export function toCreateAPyramidTower(numberOfFloorsOfTheTower) {
    const pyramid = [];
    const maxWidth = 2 * numberOfFloorsOfTheTower - 1;

    for (let i = 0; i < numberOfFloorsOfTheTower; i++) {
        const currentFloorWidth = 2 * i + 1;
        const padding = (maxWidth - currentFloorWidth) / 2;
        const floor = ' '.repeat(padding) + '*'.repeat(currentFloorWidth) + ' '.repeat(padding);
        pyramid.push(floor);
    }
    return pyramid;
}