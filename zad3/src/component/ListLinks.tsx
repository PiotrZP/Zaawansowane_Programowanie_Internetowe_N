import React from "react";
import ILinkElement from "../model/ILinkElement";
import { IListLinkState } from "../model/IListLinkState";
import { LinkListElement } from "./LinkListElement";


export class ListLinks extends React.Component<{links: Array<ILinkElement>},IListLinkState>{
    
    constructor(props: {links: Array<ILinkElement>}){
        super(props);

        this.state = {
            links: this.props.links,
        }

    }
    
    render(){
        return(
            <div className="listLinks-conteiner">
                {
                    this.state.links.map(link => 
                        <LinkListElement
                            id={link.id}
                            key={link.id}
                            siteAddress={link.siteAddress}
                            describtion={link.describtion}
                            title={link.title}
                            color={link.color}
                        ></LinkListElement>
                        )
                }
                
            </div>
        );
    }
}