import React from "react";
import {Screen} from "./Screen"
import { Buttons } from "./Buttons";
import { IScreenState } from '../model/ScreenState';

export class MainContainer extends React.Component<any, IScreenState>{

    constructor(props: any)
    {
        super(props);
        this.state = {value: 0,};
        //this.handleAddOneClick = this.handleAddOneClick.bind(this);
        //this.handleSubtrackOneClick = this.handleSubtrackOneClick.bind(this);
            
    }

    handleButtonClick = (operationValue: number) => {
        let newState = {...this.state};
        newState.value += operationValue;
        this.setState( newState)    
    }

    render(){
        return(
            <div>
                <Screen value={this.state.value}></Screen>
                <Buttons onButtonClick = {this.handleButtonClick}></Buttons>
            </div>
        )
    }
    
}