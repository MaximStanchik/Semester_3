export function toInformAboutOrderAcceptance(amountOfFunds, costOfGood, amountOfGoods, totalCostOfGoods = 0, choiceIfThereAreNotEnoughFunds) {
    while (true) {
        for (let amountOfGoods = 0; amountOfGoods < costOfGood.length; amountOfGoods++) {
            if (costOfGood[amountOfGoods] === "стоп") {
                break;
            }
            else {
                if (!isNaN(parseFloat(costOfGood[amountOfGoods]))) {
                    totalCostOfGoods += parseFloat(costOfGood[amountOfGoods]);
                    if (amountOfFunds < totalCostOfGoods[amountOfGoods]) {
                        return 1;
                    }
                    else if (amountOfFunds < totalCostOfGoods[amountOfGoods] && choiceIfThereAreNotEnoughFunds == 0) {
                        totalCostOfGoods -= parseFloat(costOfGood[amountOfGoods]);
                        return totalCostOfGoods;
                    }
                    else if (amountOfFunds < totalCostOfGoods[amountOfGoods] && choiceIfThereAreNotEnoughFunds == 1) {
                        totalCostOfGoods = costOfGood[goodSerialNumber];
                        return totalCostOfGoods;
                    }
                }
                else {
                    return 0;
                }
            }
        }
    }
}