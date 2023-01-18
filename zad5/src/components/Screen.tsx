import React from 'react'
import {IScreenState} from "../model/ScreenState"

//Aby stworzyć dany typ stanu musi być on przekazany jako drugi argument, pierwszym musi być property z rodzica.
//Aby przekazać ustalić typ tylko dla stanu pierwszym parametrem musi być any czyli dowolne rzeczy a drugi to typ
export class Screen extends React.Component<{value: number}>{

    render(): React.ReactNode{
        return (
            <div id="screen">
                <p>{this.props.value}</p>
            </div>
        );
    }
}