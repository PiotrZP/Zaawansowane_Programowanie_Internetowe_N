import React, {FC, useContext} from "react";
import { Zad8Context } from "./Zad8First";

export const Zad8Second: FC<{}> = ({}) => {
    const { state, setState } = useContext(Zad8Context);

    const handleSelfVisibility = (e: React.MouseEvent<HTMLButtonElement>) => {
        setState({
            ...state,
            second: !state.second
        })
    }
    
    return (
        <div style={{ display: state.second ? 'block' : 'none' }}>
            <p>Komunikat komponentu 2</p>
            <button onClick={handleSelfVisibility} type="button">Ukryj mnie za pomocą kontekstu!</button>
        </div>
    )
}