import React, { createContext, useMemo, useState } from 'react';
import { IAddress } from '../models/IAddress';
import axios from 'axios';

type IProps = {
  children: React.ReactNode;
};

interface AddressesContext {
  addresses: IAddress[];
  isLoading: boolean;
  getAddresses: () => void,
}

const AddressesInitialData: AddressesContext = {
  addresses: [],
  isLoading: false,
  getAddresses: async () => {
    return await axios.get<IAddress[]>("/api/Address");
  }
};

const AddressContext = createContext<AddressesContext>(AddressesInitialData);

export const AddressProvider = (props: IProps) => {
  const [state, setState] = useState<AddressesContext>(AddressesInitialData);

  const contextValue = useMemo(() => {
    return {
      state,
      setState,
      ...AddressesInitialData,
    };
  }, [state]);


  return (
    <AddressContext.Provider value={contextValue}>
      {props.children}
    </AddressContext.Provider>
  );
};