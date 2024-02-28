export function toReverseAndFilter(str) {
    const reversed = str.split('').reverse().join('');
    const filtered = reversed.replace(/[^a-zA-Z]/g, '');
  
    return filtered;
  }