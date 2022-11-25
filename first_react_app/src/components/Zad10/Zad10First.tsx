import React, {FC, createContext, useState} from "react";
import { Zad10Second } from "./Zad10Second";

type ContextType = { 
    first: boolean
    second: boolean,
    answer: boolean,
    showInfo: boolean
}

const contextInitialValue = {
    state: { first: true, second: false, answer: false, showInfo: false },
    setState: (state: ContextType) => {}
};

export const Zad10Context = createContext(contextInitialValue);

export const Zad10First: FC<{}> = ({}) => {
    const [state, setState] = useState(contextInitialValue.state);

    const handleSecondComponentVisibility = (e: React.MouseEvent<HTMLButtonElement>) => {
        setState({
            ...state,
            second: !state.second,
            showInfo: false
        })
    }

    return (
        <Zad10Context.Provider value={{ state, setState }}>
            <div>
                <button className="spacing" onClick={handleSecondComponentVisibility} type="submit">Odkryj ukryty komponent</button>
                <Zad10Second/>
                { state.showInfo &&
                    <p>
                        { state.answer ? 'Cieszę się! Idźmy dalej!' : 'Przykro mi, że się męczysz!' }
                    </p>
                }
            </div>
        </Zad10Context.Provider>
    )
}