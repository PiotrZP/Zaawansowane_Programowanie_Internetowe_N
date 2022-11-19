import React, { useState } from 'react';
import IProduct from '../models/IProduct';
import ProductListItem from './ProductListItem';
import { IProductListState } from '../models/IProductListState';

import './ProductList.css';
import AddProductToList from './AddProductToList';

function ProductList(props: { products: Array<IProduct> }) {
  const [state, setState] = useState<IProductListState>({
    name: '',
    products: props.products.length >= 0 ? props.products : [],
  });

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newState = { ...state };
    newState['name'] = e.target.value;

    setState({
      ...newState,
    });
  };

  const onAddNewProductSubmit = (product: IProduct) => {
    let newState = { ...state };
    newState.products.push(product);
    setState(newState);
  };

  return (
    <div className="product-list">
      <div className="product-list-name-change-container">
        <label htmlFor="input-product">Podaj nazwę produktu: </label>
        <input type="text" onChange={onInputChange} id="input-product"></input>
      </div>

      <div className="product-list-name-container">
        <span className="product-list-name-text">{state.name}</span>
      </div>
    
      <h3>Produkty:</h3>
      <div className="list-container">
        {state.name !== '' &&
          state.products.map((product) => (
            <ProductListItem
              id={product.id}
              key={product.id}
              name={product.name}
              type={product.type}
              price={product.price}
            ></ProductListItem>
          ))}
      </div>

      <AddProductToList submit={onAddNewProductSubmit}></AddProductToList>
    </div>
  );
}

export default ProductList;
