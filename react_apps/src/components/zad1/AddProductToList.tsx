import { ChangeEvent, FormEvent, useCallback, useState } from "react";
import IProduct from "../../model/IProductProps";
import { IAddProductToListProps } from "../../model/IAddProductToListProps";
import "../../styles/AddProductToList.css";

const initialProduct: IProduct = {
  id: 0,
  name: "",
  type: "",
  price: 0,
};

const AddProductToList = (props: IAddProductToListProps) => {
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
    <div className="form-container">
      <form onSubmit={onSubmit}>
        <h4>Add product</h4>
        <div className="product-item-element">
          <span>Id</span>
          <input
            className="product-item-input"
            name="id"
            placeholder="id"
            onChange={onInputChange}
            value={newProduct.id}
          />
        </div>
        <div className="product-item-element">
          <span>Name</span>
          <input
            className="product-item-input"
            name="name"
            placeholder="name"
            onChange={onInputChange}
            value={newProduct.name}
          />
        </div>
        <div className="product-item-element">
          <span>Type</span>
          <input
            className="product-item-input"
            name="type"
            placeholder="type"
            onChange={onInputChange}
            value={newProduct.type}
          />
        </div>
        <div className="product-item-element">
          <span>Price</span>
          <input
            className="product-item-input"
            name="price"
            placeholder="price"
            onChange={onInputChange}
            value={newProduct.price}
          />
        </div>
        <button className="product-item-submit-button" type="submit">
          Add
        </button>
        {error && (
          <span className="product-item-error">
            Product with this id already exists!
          </span>
        )}
      </form>
    </div>
  );
};
export default AddProductToList;
