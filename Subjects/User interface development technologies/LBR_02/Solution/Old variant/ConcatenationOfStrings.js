export function toCombineParameters(param1 = "Default", param2, param3) {
    if (param3 === undefined) {
        return 1;
    }
    return param1 + param2 + param3;
}