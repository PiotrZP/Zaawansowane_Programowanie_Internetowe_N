import React, { useState, useContext, useMemo, createContext } from "react";
import { IAddress } from "../models/IAddress";

type IProps = {
    children: React.ReactNode
}

interface AddressesContext {
    state: {
        addresses: IAddress[],
        isLoading: boolean,
    },
    setState: () => void,
}

const AddressesInitialData : AddressesContext = {
    state: {
        addresses: [],
        isLoading: false,
    },
    setState: () => null,
}

const AddressContext = createContext<AddressesContext>(AddressesInitialData)

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
