import IProduct from "./IProduct";

export interface IProductListState{
    products: Array<IProduct>;
    showList: boolean;
    buttonName: string;
}

