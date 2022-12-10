import IProductProps from "./IProductProps";

export interface IAddProductToListProps {
  addProduct: (product: IProductProps) => boolean;
}
