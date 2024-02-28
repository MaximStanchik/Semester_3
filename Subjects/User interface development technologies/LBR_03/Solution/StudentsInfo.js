export function toFilterStudentsByGroup(students) {
    const result = {};
  
    for (let i = 0; i < students.length; i++) {
      const student = students[i];
  
      if (student.age > 17) {
        const groupId = student.groupId;
  
        if (!result[groupId]) {
          result[groupId] = [];
        }
  
        result[groupId].push(student);
      }
    }
  
    return result;
  }

export function toValidateInput(input) {
    if (/^\d+$/.test(input)) {
      return parseInt(input, 10);
    }
    return null;
  }