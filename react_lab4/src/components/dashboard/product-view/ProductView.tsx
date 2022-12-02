import React, { useCallback, useEffect, useState } from "react";
import { getProductsRequest } from "../../../api/ProductController";
import Product from "../../../models/common/Product";
import CustomHeader from "../../common/custom-header/CustomHeader";
import CustomTab from "../../common/custom-tab/CustomTab";
import ProductAdd from "./components/product-add/ProductAdd";
import ProductDelete from "./components/product-delete/ProductDelete";
import ProductEdit from "./components/product-edit/ProductEdit";
import ProductList from "./components/product-list/ProductList";
import "./ProductView.css";

const ProductView = (): JSX.Element => {
  const [products, setProducts] = useState<Product[]>([]);

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
    <div className="product-main-container">
      <CustomHeader title="Produkty" />
      <CustomTab
        listComponent={<ProductList />}
        addComponent={<ProductAdd />}
        editComponent={<ProductEdit />}
        deleteComponent={<ProductDelete />}
      />
    </div>
  );
};

export default ProductView;
