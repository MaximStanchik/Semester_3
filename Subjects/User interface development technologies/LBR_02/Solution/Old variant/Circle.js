export function calculateCircleProperties(radiusOfCircle) {
    if (!isNaN(radiusOfCircle)) {
        const parsedRadiusOfCircle = parseFloat(radiusOfCircle);
        const area = Math.PI * parsedRadiusOfCircle * parsedRadiusOfCircle;
        const diameter = 2 * parsedRadiusOfCircle;
        const circumference = 2 * Math.PI * parsedRadiusOfCircle;
        return {
            area: area,
            diameter: diameter,
            circumference: circumference
        };
    } else {
        return null;
    }
}