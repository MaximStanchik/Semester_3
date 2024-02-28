function toCalculateTheTimeToGuessThePassword() {
    const passwordLength = 8;
    const lettersCount = 5;
    const digitsCount = 3;
    const lettersPermutations = 26 ** lettersCount;
    const digitsPermutations = 10 ** digitsCount;

    const totalPermutations = lettersPermutations * digitsPermutations;

    const secondsPerPassword = 3;
    const totalTimeInSeconds = totalPermutations * secondsPerPassword;

    const secondsInMinute = 60;
    const minutesInHour = 60;
    const hoursInDay = 24;
    const daysInMonth = 30;
    const monthsInYear = 12;

    const seconds = totalTimeInSeconds % secondsInMinute;
    const minutes = Math.floor(totalTimeInSeconds / secondsInMinute) % minutesInHour;
    const hours = Math.floor(totalTimeInSeconds / (secondsInMinute * minutesInHour)) % hoursInDay;
    const days = Math.floor(totalTimeInSeconds / (secondsInMinute * minutesInHour * hoursInDay)) % daysInMonth;
    const months = Math.floor(totalTimeInSeconds / (secondsInMinute * minutesInHour * hoursInDay * daysInMonth)) % monthsInYear;
    const years = Math.floor(totalTimeInSeconds / (secondsInMinute * minutesInHour * hoursInDay * daysInMonth * monthsInYear));

    const result = years + " лет " + months + " месяцев " + days + " дней " + hours + " часов " + minutes + " минут " + seconds + " секунд";
}

