import React from "react";
import { IScreenState } from "../model/ScreenState";
import "./Buttons.css"

export class Buttons extends React.Component<any>{
    
    handleAddOneClick = () => {
        this.props.onButtonClick(1);
    }
    
    handleSubtrackOneClick = () => {
        this.props.onButtonClick(-1);
    }
    
    handleAddTwoClick = () => {
        this.props.onButtonClick(2);
    }
    
    handleSubtracktTwoClick = () => {
        this.props.onButtonClick(-2);
    }


    render(): React.ReactNode {
        return(
            <div >
                <input type="button" id="ButtonMinus" value="-1" onClick={this.handleSubtrackOneClick}></input>
                <input type="button" id="ButtonPlus" value="+1" onClick={this.handleAddOneClick}></input>
                <br></br>
                <br></br>
                <input type="button" id="ButtonMinus" value="-2" onClick={this.handleSubtracktTwoClick}></input>
                <input type="button" id="ButtonPlus" value="+2" onClick={this.handleAddTwoClick}></input>
            </div>
        );
    }
}