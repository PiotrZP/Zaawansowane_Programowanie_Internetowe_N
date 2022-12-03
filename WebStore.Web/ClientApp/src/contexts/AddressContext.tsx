import React, { useState, useContext, useMemo, createContext } from "react";
import { IAddress } from "../models/IAddress";

type IProps = {
    children: React.ReactNode
}
type IStateAddress = {
    addresses: IAddress[]
}
type ContextType = {
    state: {
        addresses: [],
    },
    setState: (state: ContextType) => void,
}
const contextInitialValue : ContextType = {
    state: {
        addresses: []
    },
    setState: (state: ContextType) => {}
}
const AddressContext = createContext(contextInitialValue);

export const AddressProvider = (props: IProps) => {
    const [state, setState] = useState(contextInitialValue.state);
    const contextValue = useMemo(() => {
        return {
            state,
            setState,
        };
    }, [state]);
    
    return(
        <AddressContext.Provider value={contextValue}>

        </AddressContext.Provider>
    )
}
