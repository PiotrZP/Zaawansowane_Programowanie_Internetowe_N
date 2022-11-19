import React, { FC, useState } from "react";
import { IProductListState } from "../models/IProductListState";
import "./ProductListItem.css";
import ProductListItem from "./ProductListItem";
import AddProductToList from "./AddProductToList";
import IProduct from "../models/IProduct";
import "./ProductList.css";

const ProductList: FC<IProductListState> = ({ products }) => {
  const [product, setProduct] = useState(products);
  const [name, setName] = useState("");

  const onAddNewProductSubmit = (product: IProduct) => {
    setProduct((prev) => [...prev, product]);
  };

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setName((prev) => (prev = e.target.value));
  };

  return (
    <div className="product-list">
      <div className="product-list-name-change-container">
        <input type="text" onChange={onInputChange}></input>
      </div>
      <div className="product-list-name-container">
        <span className="product-list-name-text">{name}</span>
      </div>
      <div className="list-container">
        {name !== "" &&
          product.map((item) => (
            <ProductListItem
              id={item.id}
              key={item.id}
              name={item.name}
              type={item.type}
              price={item.price}
            ></ProductListItem>
          ))}
      </div>
      <AddProductToList submit={onAddNewProductSubmit} />
    </div>
  );
};

export default ProductList;
