import { ChangeEvent, FormEvent, useCallback, useState } from "react";
import IProduct from "src/models/IProduct";
import { AddProductToListProps } from "./AddProductToListProps";
import "./AddProductToList.css";

const initialProduct: IProduct = {
  id: 0,
  name: "",
  type: "",
  price: 0.0,
};

const AddProductToList = (props: AddProductToListProps): JSX.Element => {
  const { addProduct } = props;
  const [newProduct, setNewProduct] = useState<IProduct>(initialProduct);
  const [error, setError] = useState(false);

  const onSubmit = useCallback(
    (event: FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      const result = addProduct(newProduct);
      setError(!result);
      setNewProduct(initialProduct);
    },
    [addProduct, newProduct]
  );

  const onInputChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      const product = {
        ...newProduct,
        [event.target.name]: event.target.value,
      };
      setNewProduct(product);
    },
    [newProduct]
  );

  return (
    <div className="aptl-form-container">
      <form onSubmit={onSubmit}>
        <h4>Add product</h4>
        <div className="aptl-product-item-element">
          <span>Id</span>
          <input
            className="aptl-product-item-input"
            name="id"
            placeholder="id"
            onChange={onInputChange}
            value={newProduct.id}
          />
        </div>
        <div className="aptl-product-item-element">
          <span>Name</span>
          <input
            className="aptl-product-item-input"
            name="name"
            placeholder="name"
            onChange={onInputChange}
            value={newProduct.name}
          />
        </div>
        <div className="aptl-product-item-element">
          <span>Type</span>
          <input
            className="aptl-product-item-input"
            name="type"
            placeholder="type"
            onChange={onInputChange}
            value={newProduct.type}
          />
        </div>
        <div className="aptl-product-item-element">
          <span>Price</span>
          <input
            className="aptl-product-item-input"
            name="price"
            placeholder="price"
            onChange={onInputChange}
            value={newProduct.price}
          />
        </div>
        <button className="aptl-product-item-submit-button" type="submit">
          Add
        </button>
        {error && (
          <span className="aptl-product-item-error">
            Product with this id already exists!
          </span>
        )}
      </form>
    </div>
  );
};

export default AddProductToList;
