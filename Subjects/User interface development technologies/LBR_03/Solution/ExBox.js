export function toExBox(start, cur) {
    if (Array.isArray(cur))
        cur.reduce(toExBox, start);
    else
        start.push(cur);

    return start;
}