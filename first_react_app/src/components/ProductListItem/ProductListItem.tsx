import React, { FC } from "react";
import IProduct from "../../models/IProduct";
import './styles.scss';

export const ProductListItem: FC<IProduct> = ({ id, name, price, type }) => {
    return (
        <div className="product-wrapper">
            <div className="general-wrapper">
                <div className="product">
                    <p className="label">Id</p>
                    <p className="value">{id}</p>
                </div>
                <div className="product">
                    <p className="label">Name</p>
                    <p className="value">{name}</p>
                </div>
                <div className="product">
                    <p className="label">Price</p>
                    <p className="value">{price}</p>
                </div>
                <div className="product">
                    <p className="label">Type</p>
                    <p className="value">{type}</p>
                </div>
            </div>
        </div>
    )
}