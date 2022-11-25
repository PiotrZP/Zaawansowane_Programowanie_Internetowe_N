import React, {FC, useContext} from "react";
import { Zad10Context } from "./Zad10First";

export const Zad10Second: FC<{}> = ({}) => {
    const { state, setState } = useContext(Zad10Context);

    const handleLearningStatus = (answer: boolean) => {
        setState({
            ...state,
            second: !state.second,
            answer: answer,
            showInfo: true
        })
    }
    
    return (
        <div style={{ display: state.second ? 'block' : 'none' }}>
            <p>Czy chcesz dalej uczyć się biblioteki React?</p>
            <div>
                <button onClick={() => handleLearningStatus(true)} type="button">Tak!</button>
                <button onClick={() => handleLearningStatus(false)} type="button">Nie!</button>

            </div>
        </div>
    )
}