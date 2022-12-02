import React, { FC } from "react";
import IProduct from "../models/IProduct";
import "./ProductListItem.css";

const ProductListItem: FC<IProduct> = ({ id, name, price, type }) => {
  return (
    <div className="product-item">
      <div className="product-item-element">
        <label className="product-item-label">Id</label>
        <span className="product-item-span">{id}</span>
      </div>
      <div className="product-item-element">
        <label className="product-item-label">Name</label>
        <span className="product-item-span">{name}</span>
      </div>
      <div className="product-item-element">
        <label className="product-item-label">Price</label>
        <span className="product-item-span">{price}</span>
      </div>
      <div className="product-item-element">
        <label className="product-item-label">Type</label>
        <span className="product-item-span">{type}</span>
      </div>
    </div>
  );
};

export default ProductListItem;