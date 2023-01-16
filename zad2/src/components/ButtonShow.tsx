import React from "react";
import { ReactNode } from "react";
import { IButtonState } from "../model/IButtonState";
import IPerson from "../model/IPerson";
import { PersonView } from "./PersonView";

export class ButtonShow extends React.Component<{person: IPerson},IButtonState>{

    constructor(props: {person: IPerson}){
        super(props);
        this.state = {
            person: this.props.person,
            buttonName: "Show Names",
            datesAreHide: true
        }
    }

    showOrHide = () => {
        let newState = {...this.state};
        if(this.state.datesAreHide == false){
            newState.buttonName = "Show Names";
            newState.datesAreHide = true;
        }
        else{
            newState.buttonName = "Hide Names";
            newState.datesAreHide = false;
        }

        this.setState(newState);
    }

    render(){
        return(
            <div className="buttonShow">
                
                <input type="button" value={this.state.buttonName} onClick={this.showOrHide}></input>

                <div className="names-container">                    
                    {
                        this.state.datesAreHide == false &&
                            <PersonView 
                                firstName={this.state.person.firstName}
                                lastName={this.state.person.lastName}
                            ></PersonView>
                    }                    
                </div>
            </div>
        );
    }
}