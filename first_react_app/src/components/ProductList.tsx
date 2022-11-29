import React from "react";
import { IProductListState } from "../models/IProductListState";
import './ProductList.css'
import IProduct from "../models/IProduct";
import { ProductListItem } from "./ProductListItem";
import { AddProductToList } from "./AddProductToList";
import { Console } from "console";
export class ProductList extends React.Component<{products: Array<IProduct>}, IProductListState>{

    constructor(props: {products: Array<IProduct>}){
        super(props);
        this.state = {
            products: this.props.products != null? this.props.products : [],
            showList: false,
            buttonName: "Show list Element"
        }
    }

    onAddNewProductSubmit = (product: IProduct) =>{
        let newState ={...this.state}
        newState.products.push(product);
        this.setState(newState);
    }

    showOrHideListElements = () =>{
        let newState = {...this.state}
        if(newState.showList === false)
        {
            newState.showList = true;
            newState.buttonName = "Hide List Element"
            this.setState(newState);
        }
        else
        {
            newState.showList = false;
            newState.buttonName = "Show list Element"
            this.setState(newState);
        }
        
    }
    render(){
        return(
            <div className="product-list">
                <div className="product-list-name-change-container">
                    {/* <input type="text" onChange={this.onInputChange}></input> */}
                    <input type="button" className="buttonClass" onClick={this.showOrHideListElements} value={this.state.buttonName} ></input>
                </div>

                <div className="list-container">
                    {
                        this.state.showList == true &&
                        this.state.products.map(product =>
                            <ProductListItem id={product.id}
                                key={product.id}
                                name={product.name}
                                type={product.type}
                                price={product.price}></ProductListItem>
                            )
                    }
                </div>
                <AddProductToList submit={this.onAddNewProductSubmit}></AddProductToList>
            </div>
        )
    }
}