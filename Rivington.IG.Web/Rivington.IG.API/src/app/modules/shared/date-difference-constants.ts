export const DateDifferenceConstants = {
    ZeroToNineteenDays: {
        min: 0,
        max: 19,
        colorPalette: "28a745",
        toString: () => {
            return `${DateDifferenceConstants.ZeroToNineteenDays.min}-${DateDifferenceConstants.ZeroToNineteenDays.max}`;
        }
    },
    TwentyToThirtyNineDays: {
        min: 20,
        max: 39,
        colorPalette: "ffb22b",
        toString: () => {
            return `${DateDifferenceConstants.TwentyToThirtyNineDays.min}-${DateDifferenceConstants.TwentyToThirtyNineDays.max}`;
        }
    },
    FortyToFiftyNineDays: {
        min: 40,
        max: 59,
        colorPalette: "fc4b6c",
        toString: () => {
            return `40 and above`;
        }
    }
};