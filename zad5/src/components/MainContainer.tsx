import React from "react";
import {Screen} from "./Screen"
import { Buttons } from "./Buttons";
import { IScreenState } from '../model/ScreenState';

export class MainContainer extends React.Component<any, IScreenState>{

    constructor(props: any)
    {
        super(props);
        this.state = {value: 0,};
        this.handleAddOneClick = this.handleAddOneClick.bind(this);
        this.handleSubtrackOneClick = this.handleSubtrackOneClick.bind(this);
            
    }

    handleAddOneClick = () => {
        let newState = {...this.state};
        newState.value += 1;
        this.setState( newState)    
    }

    handleSubtrackOneClick = () => {
        let newState = {...this.state};
        newState.value -= 1;
        this.setState( newState)    
    }

    render(){
        return(
            <div>
                <Screen value={this.state.value}></Screen>
                <Buttons onAddClick = {this.handleAddOneClick} onSubtrackClick = {this.handleSubtrackOneClick}></Buttons>
            </div>
        )
    }
    
}