import React, {FC, createContext, useState} from "react";
import { Zad8Second } from "./Zad8Second";

type ContextType = { 
    first: boolean
    second: boolean
}

const contextInitialValue = {
    state: { first: true, second: false },
    setState: (state: ContextType) => {}
};

export const Zad8Context = createContext(contextInitialValue);

export const Zad8First: FC<{}> = ({}) => {
    const [state, setState] = useState(contextInitialValue.state);

    const handleSecondComponentVisibility = (e: React.MouseEvent<HTMLButtonElement>) => {
        setState({
            ...state,
            second: !state.second
        })
    }

    return (
        <Zad8Context.Provider value={{ state, setState }}>
            <div>
                <p>Kliknij przycisk poniżej aby wyświetlić drugi komponent</p>
                <button className="spacing" onClick={handleSecondComponentVisibility} type="submit">pokaż</button>
                <Zad8Second/>
            </div>
        </Zad8Context.Provider>
    )
}