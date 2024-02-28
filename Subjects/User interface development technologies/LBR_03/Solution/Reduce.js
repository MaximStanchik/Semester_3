export function toReduseArrays (Array_1, Array_2) {
    const combinedArray = Array_2.reduce((result, currentElement) => {
        return result.concat([currentElement]);
      }, Array_1);
}
