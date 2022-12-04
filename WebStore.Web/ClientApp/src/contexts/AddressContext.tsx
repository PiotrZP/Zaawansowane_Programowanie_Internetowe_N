import React, { createContext, useMemo, useState } from 'react';
import { IAddress } from '../models/IAddress';
import axios from 'axios';

type IProps = {
  children: React.ReactNode;
};

interface Addresses {
    addresses: IAddress[];
    isLoading: boolean;
    getAddresses: () => void,
}

interface IAddressContext {
    state: Addresses
    setState: (state: Addresses) => void
}
 
const AddressesInitialData: IAddressContext = {
    state: {
        addresses: [],
        isLoading: false,
        getAddresses: async () => {
          return await axios.get<IAddress[]>("/api/Address");
        }
    },
    setState: (state: Addresses) => {}
};


const AddressContext = createContext<IAddressContext>(AddressesInitialData);
export default AddressContext;

export const AddressProvider = (props: IProps) => {
  const [state, setState] = useState<Addresses>(AddressesInitialData.state);

  const contextValue = useMemo(() => {
    return {
      state,
      setState
    };
  }, [state]);


  return (
    <AddressContext.Provider value={{state,setState}}>
      {props.children}
    </AddressContext.Provider>
  );
};