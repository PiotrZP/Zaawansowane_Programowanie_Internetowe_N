import IProduct from "./IProduct";

export interface IAddProductToList {
  addProduct: (product: IProduct) => boolean;
}