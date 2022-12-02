import IProduct from "src/models/IProduct";

export default interface ProductListProps {
  products: IProduct[];
  name?: string;
}
