import IProduct from '../models/IProduct';

import './ProductListItem.css';


export default function ProductListItem(props: IProduct) {
  return (
    <div className="product-item">
      <div className="product-item-element">
        <b className="product-item-label">ID: </b>
        <span className="product-item-span">{props.id}</span>
      </div>
      <div className="product-item-element">
        <b className="product-item-label">Name: </b>
        <span className="product-item-span">{props.name}</span>
      </div>
      <div className="product-item-element">
        <b className="product-item-label">Price: </b>
        <span className="product-item-span">{props.price}</span>
      </div>
      <div className="product-item-element">
        <b className="product-item-label">Type: </b>
        <span className="product-item-span">{props.type}</span>
      </div>
    </div>
  );
}
