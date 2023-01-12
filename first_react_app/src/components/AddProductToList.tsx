import React, { FC, useState } from "react";
import IProduct from "../models/IProduct";
import "./AddProductToList.css";

interface AddProductToListProps {
  submit: (product: IProduct) => void;
}

const AddProductToList: FC<AddProductToListProps> = ({ submit }) => {
  const [newProduct, setNewProduct] = useState({
    id: 0,
    name: "",
    type: "",
    price: 0.0,
  });

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    let newState = { ...newProduct } as any;
    newState[e.target.name] = e.target.value;
    setNewProduct(newState);
  };

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    submit(newProduct);
    setNewProduct((prev) => ({ ...prev, newProduct: undefined }));
  };

  return (
    <div className="form-container">

      <form onSubmit={onSubmit}>
        <div className="product-item-element">
          <input
            className="product-item-input"
            name="id"
            placeholder="Id"
            onChange={onInputChange}
            value={newProduct.id}
          ></input>
        </div>
        <div className="product-item-element">
          <input
            className="product-item-input"
            name="name"
            placeholder="name"
            onChange={onInputChange}
            value={newProduct.name}
          ></input>
        </div>
        <div className="product-item-element">
          <input
            className="product-item-input"
            name="type"
            placeholder="Type"
            onChange={onInputChange}
            value={newProduct.type}
          ></input>
        </div>
        <div className="product-item-element">
          <input
            className="product-item-input"
            name="price"
            placeholder="Price"
            onChange={onInputChange}
            value={newProduct.price}
          ></input>
        </div>
        <button type="submit">Add</button>
      </form>
    </div>
  );
};

export default AddProductToList;