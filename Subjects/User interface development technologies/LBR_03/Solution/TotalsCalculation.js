export function toCalculateTotals(inputString) {
    let total1 = 0;
    let total2 = 0;
  
    for (let i = 0; i < inputString.length; i++) {
      const charCode = inputString.charCodeAt(i);
      total1 += charCode;
  
      if (charCode[i] === '7') {
        total2 += 1;
      }
    }
  
    const result = total1 - total2;
    return result;
  }