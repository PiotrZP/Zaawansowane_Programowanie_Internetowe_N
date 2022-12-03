import React, { useState, useContext, useMemo, createContext } from "react";
import { IAddress } from "../models/IAddress";

type IProps = {
    children: React.ReactNode
}

interface IContextValue {
    state: {
        addresses: IAddress[]
    },
    setState: (state: IContextValue) => void,
}

const AddressContext = createContext<IContextValue>({
    state: {
        addresses: []
    },
    setState: () => {},
})


export const AddressProvider = (props: IProps) => {
    const [state, setState] = useState(AddressContext);
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
