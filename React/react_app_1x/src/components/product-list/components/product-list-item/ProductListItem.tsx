import "./ProductListItem.css";
import ProductListItemProps from "./ProductListItemProps";

const ProductListItem = (props: ProductListItemProps): JSX.Element => {
  const { id, name, price, type } = props;

  return (
    <div className="pli-product-item">
      <div className="pli-product-item-element">
        <label>Id</label>
        <span>{id}</span>
      </div>
      <div className="pli-product-item-element">
        <label>Name</label>
        <span>{name}</span>
      </div>
      <div className="pli-product-item-element">
        <label>Price</label>
        <span>{price}</span>
      </div>
      <div className="pli-product-item-element">
        <label>Type</label>
        <span>{type}</span>
      </div>
    </div>
  );
};

export default ProductListItem;
