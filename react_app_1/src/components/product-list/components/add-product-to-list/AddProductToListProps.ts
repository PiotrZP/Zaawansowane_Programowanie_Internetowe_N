import IProduct from "src/models/IProduct";

export interface AddProductToListProps {
  addProduct: (product: IProduct) => boolean;
}
