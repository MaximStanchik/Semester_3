export function toGetUniqueStrings(array1, array2) {
    const array3 = [];
  
    for (let i = 0; i < array1.length; i++) {
      if (!array2.includes(array1[i])) {
        array3.push(array1[i]);
      }
    }
  
    return arr3;
  }

 