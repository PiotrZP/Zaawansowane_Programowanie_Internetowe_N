import { ChangeEvent, useCallback, useState } from "react";
import IProduct from "../../model/IProduct";
import IProductList from "../../model/IProductList";
import AddProductToList from "../AddProductToList/AddProductToList";
import ProductListItem from "../ProductListItem/ProductListItem";

const ProductList = (props: IProductList) => {
  const { products, name } = props;
  const [listName, setListName] = useState(name ? name : "");
  const [productList, setProductList] = useState<IProduct[]>(products);

  const handleChangeListName = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      setListName(event.target.value);
    },
    []
  );

  const handleAddProduct = useCallback(
    (newProduct: IProduct): boolean => {
      if (productList.some((product) => product.id === newProduct.id)) {
        return false;
      }
      const newList = [...productList, newProduct].sort((a, b) => a.id - b.id);
      setProductList(newList);
      return true;
    },
    [productList]
  );

  return (
    <div className="product-list">
      <div className="product-list-head-container">
        <AddProductToList
          addProduct={(newProduct: IProduct) => handleAddProduct(newProduct)}
        />
        <div className="product-list-name-change-container">
          <h4>Change list name</h4>
          <div>
            <span>List name</span>
            <input
              className="product-list-title-input"
              type="text"
              onChange={handleChangeListName}
            />
          </div>
        </div>
      </div>
      <div className="product-list-name-container">
        <span className="product-list-name-text">
          <h2>{listName ? listName : " - BRAK NAZWY -"}</h2>
        </span>
      </div>
      <div className="list-container">
        {productList.map((product) => (
          <ProductListItem
            id={product.id}
            key={product.id}
            name={product.name}
            type={product.type}
            price={product.price}
          />
        ))}
      </div>
    </div>
  );
};

export default ProductList;
