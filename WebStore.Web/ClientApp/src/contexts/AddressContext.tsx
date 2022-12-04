import React, { createContext, useMemo, useState } from 'react';
import { IAddress } from '../models/IAddress';
import axios from 'axios';

type IProps = {
  children: React.ReactNode;
};

interface AddressesContext {
    state:{
        addresses: IAddress[];
        isLoading: boolean;
        getAddresses: () => void,
    }
    setState: (state: AddressesContext) => void
}

export const AddressesInitialData: AddressesContext = {
    state: {
        addresses: [],
        isLoading: false,
        getAddresses: async () => {
          return await axios.get<IAddress[]>("/api/Address");
        }
    },
    setState: (state: AddressesContext) => {}
};

const AddressContext = createContext<AddressesContext>(AddressesInitialData);
export default AddressContext;

export const AddressProvider = (props: IProps) => {
  const [state, setState] = useState<AddressesContext>(AddressesInitialData.state);

  const contextValue = useMemo(() => {
    return {
      state,
      setState
    };
  }, [state]);


  return (
    <AddressContext.Provider value={contextValue}>
      {props.children}
    </AddressContext.Provider>
  );
};