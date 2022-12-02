import React, { FC, useState, ChangeEvent } from "react";
import { IProductListState } from "../../models/IProductListState";
import IProduct from "../../models/IProduct";
import { ProductListItem } from "../ProductListItem/ProductListItem";
import './styles.scss';
import { AddProductToList } from "../AddProductToList/AddProductToList";

export const ProductList: FC<IProductListState> = ({ products, name }) => {
    const [product, setProduct] = useState(products);
    const [productName, setProductName] = useState<string>(name);

    const onAddNewProductSubmit = (product: IProduct) => {
        setProduct((prev) => [...prev, product]);
    };
    

    return (
        <div className="product-list-wrapper">
            <div className="product-list-name-changer">
                <input type="text" onChange={(e: ChangeEvent<HTMLInputElement>) => {
                    setProductName(e.currentTarget.value)
                }}/>
            </div>
            <div className="product-list-name">
                <h1 className="product-list-name">{productName}</h1>
            </div>
            <div className="list-items">
                {productName !== "" &&
                    product.map((pr) => (
                        <ProductListItem 
                            key={pr.id}
                            id={pr.id}
                            name={pr.name}
                            type={pr.type}
                            price={pr.price}
                        />
                    ))
                }
            </div>
            <AddProductToList submit={onAddNewProductSubmit} />
        </div>
    )
}