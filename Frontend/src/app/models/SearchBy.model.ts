export interface SearchBy {
    Search: string;
    Category: CategoryTypes;
    Gender: GenderTypes;
    Condition: ConditionTypes;
    PriceRange: Price;
    FreeShipping: boolean;
}


export interface FilterInfo {
    buyFormat: BuyFormat;
    price: Price;
    condition: ConditionTypes;
    freeShipping: boolean;
}

export enum BuyFormat {
    All = 0,
    BuyItNow= 1,
    Auction = 2
}

export enum ConditionTypes {
    All = 0,
    New= 1,
    Used= 2
}

export interface Price {
    fromPrice: number;
    toPrice: number;
}


export enum CategoryTypes {
    All= 0,
    Clothes= 1,
    Toys = 2,
}

export enum GenderTypes {
    All = 0,
    Male = 1,
    Female = 2
}

export enum ColorTypes {
    All = 0,
    Blue = 1,
    Red = 2,
    Green = 3
}
