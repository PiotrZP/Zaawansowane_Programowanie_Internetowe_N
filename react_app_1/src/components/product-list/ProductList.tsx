import { ChangeEvent, useCallback, useState } from "react";
import ProductListProps from "./ProductListProps";
import "./ProductList.css";
import IProduct from "src/models/IProduct";
import AddProductToList from "./components/add-product-to-list/AddProductToList";
import ProductListItem from "./components/product-list-item/ProductListItem";

const ProductList = (props: ProductListProps): JSX.Element => {
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
    <div className="pl-product-list">
      <div className="pl-product-list-head-container">
        <AddProductToList
          addProduct={(newProduct: IProduct) => handleAddProduct(newProduct)}
        />
        <div className="pl-product-list-name-change-container">
          <h4>Change list name</h4>
          <div>
            <span>List name</span>
            <input
              className="pl-product-list-title-input"
              type="text"
              onChange={handleChangeListName}
            />
          </div>
        </div>
      </div>
      <div className="pl-product-list-name-container">
        <span className="pl-product-list-name-text">
          <h2>{listName ? listName : " - BRAK NAZWY -"}</h2>
        </span>
      </div>
      <div className="pl-list-container">
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
