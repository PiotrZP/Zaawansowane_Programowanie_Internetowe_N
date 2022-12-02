import React, { FC, useState } from "react";
import IProduct from "../../models/IProduct";
import './styles.scss';

interface IAddProductToList {
    submit: (product: IProduct) => void;
}

export const AddProductToList: FC<IAddProductToList> = ({ submit }) => {
    const [newProduct, addNewProduct] = useState({
        id: 0,
        name: "",
        type: "",
        price: 0.0,
    })

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        let newState = { ...newProduct } as any;
        newState[e.currentTarget.name] = e.currentTarget.value;
        addNewProduct(newState);
    };

    const handleFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        submit(newProduct);
        addNewProduct((prev) => ({ ...prev, newProduct: undefined }));
    };

    return (
        <div className="form-wrapper">
            <form onSubmit={handleFormSubmit}>
                <div className="input-group">
                    <input 
                        type="text"
                        name="id"
                        placeholder="ID"
                        onChange={handleInputChange}
                        value={newProduct.id}
                    />
                </div>
                <div className="input-group">
                    <input 
                        type="text"
                        name="name"
                        placeholder="Nazwa"
                        onChange={handleInputChange}
                        value={newProduct.name}
                    />
                </div>
                <div className="input-group">
                    <input 
                        type="text"
                        name="type"
                        placeholder="Typ"
                        onChange={handleInputChange}
                        value={newProduct.type}
                    />
                </div>
                <div className="input-group">
                    <input 
                        type="text"
                        name="price"
                        placeholder="Cena"
                        onChange={handleInputChange}
                        value={newProduct.price}
                    />
                </div>
                <div className="input-group">
                   <button type="submit">Zapisz</button>
                </div>
            </form>
        </div>
    )
}