import React from "react";
import ILinkElement from "../model/ILinkElement";
import './LinkListElement.css';

export class LinkListElement extends React.Component<ILinkElement>
{
    constructor(props: ILinkElement){
        super(props);
        this.state={
            describtion: "dupa pawiana",
        }
    }

    changeColor = () =>{
        //let newState =   
        
    }

    render(){
        return(
            <div className="link-container">
                <div className="link-container-element">
                    <label>Tytuł: </label>
                    <span>{this.props.title}</span>
                </div>
                <div className="link-container-element">
                    <label>Adres strony: </label>
                    <a href={this.props.siteAddress} style={{background: this.props.color}}>{this.props.siteAddress}</a>
                </div>
                <div className="link-container-element">
                    <label>Opis: </label>
                    <span>{this.props.describtion}</span>
                </div>
            </div>
        );
    }
}