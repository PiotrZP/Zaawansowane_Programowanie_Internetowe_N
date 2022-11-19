import React, { useState } from 'react';
import IProduct from '../models/IProduct';

function AddProductToList(props: { submit: (product: IProduct) => void }) {
  const [state, setState] = useState({
    id: 0,
    name: '',
    type: '',
    price: 0.0,
  });

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    let newState = { ...state } as any;
    newState[e.target.name] = e.target.value;

    setState(newState);
  };

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    props.submit(state);
    setState((state) => ({ ...state, newProduct: undefined }));
  };

  return (
    <div className="form-container">
      <h2>Dodaj nowy produkt</h2>
      <form onSubmit={onSubmit}>
        <div className="product-item-element">
          <label htmlFor="id">Id: </label>
          <input
            className="product-item-input"
            name="id"
            placeholder="id"
            onChange={onInputChange}
            value={state.id}
          ></input>
        </div>
        <div className="product-item-element">
          <label htmlFor="name">Name: </label>
          <input
            className="product-item-input"
            name="name"
            placeholder="name"
            onChange={onInputChange}
            value={state.name}
          ></input>
        </div>
        <div className="product-item-element">
          <label htmlFor="type">Type: </label>
          <input
            className="product-item-input"
            name="type"
            placeholder="type"
            onChange={onInputChange}
            value={state.type}
          ></input>
        </div>
        <div className="product-item-element">
          <label htmlFor="price">Price: </label>
          <input
            className="product-item-input"
            name="price"
            placeholder="price"
            onChange={onInputChange}
            value={state.price}
          ></input>
        </div>
        <button type="submit">Dodaj produkt</button>
      </form>
    </div>
  );
}

AddProductToList.propTypes = {};

export default AddProductToList;
