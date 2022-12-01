import IProductListItem from "../../model/IProductListItem";

const ProductListItem = (props: IProductListItem) => {
  const { id, name, price, type } = props;
  return (
    <div className="product-item">
      <div className="product-item-element">
        <label>Id</label>
        <span>{id}</span>
      </div>
      <div className="product-item-element">
        <label>Name</label>
        <span>{name}</span>
      </div>
      <div className="product-item-element">
        <label>Price</label>
        <span>{price}</span>
      </div>
      <div className="product-item-element">
        <label>Type</label>
        <span>{type}</span>
      </div>
    </div>
  );
};

export default ProductListItem;
