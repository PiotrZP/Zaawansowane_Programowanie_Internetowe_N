import React from "react";
import { IScreenState } from "../model/ScreenState";
import "./Buttons.css"

export class Buttons extends React.Component<any>{
    
    constructor(props: any){
        super(props);
        this.handleAddClick = this.handleAddClick.bind(this);
        this.handleSubtractClick = this.handleSubtractClick.bind(this);
    }

    handleAddClick = () => {
        this.props.onAddClick();
    }

    handleSubtractClick = () => {
        this.props.onSubtrackClick();
    }

    //ogarni o co chodzi z bindowaniem

    render(): React.ReactNode {
        return(
            <div >
                <input type="button" id="ButtonMinus" value="-" onClick={this.handleSubtractClick}></input>
                <input type="button" id="ButtonPlus" value="+" onClick={this.handleAddClick}></input>
            </div>
        );
    }
}