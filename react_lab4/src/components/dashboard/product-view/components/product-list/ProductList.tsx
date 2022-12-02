import React, { useCallback, useEffect, useState } from "react";
import { getProductsRequest } from "../../../../../api/ProductController";
import Store from "../../../../../models/common/Store";

const ProductList = () => {
  const [products, setProducts] = useState<Store[]>([]);

  const getProducts = useCallback(async () => {
    try {
      const response = await getProductsRequest();
      setProducts(response);
    } catch (ex) {
      console.log(ex);
    }
  }, []);

  useEffect(() => {
    getProducts();
  }, [getProducts]);

  return (
    <div>
      {products.map((product) => (
        <div key={product.id}>{product.name}</div>
      ))}
    </div>
  );
};

export default ProductList;
