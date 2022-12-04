import React, { useState } from "react";
import axios from "axios";
import { IProduct } from "../models/IProduct";
const ProductContext = React.createContext({});
type IProps = { children: React.ReactNode };
type IState = {
  products: IProduct[];
};
export const ProductProvider = (props: IProps) => {
  const [state, setState] = useState<IState>({ products: [] });
  const getProducts = async () => {
    const response = await axios.get<IProduct[]>("/api/ProductApi");
    setState({ products: response.data });
  };
  return (
    <ProductContext.Provider
      value={{
        state,
        getProducts,
      }}
    >
      {props.children}
    </ProductContext.Provider>
  );
};
export default ProductContext;
