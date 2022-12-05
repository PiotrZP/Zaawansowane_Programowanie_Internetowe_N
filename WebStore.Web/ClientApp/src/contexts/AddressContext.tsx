import React, { createContext, useMemo, useState } from 'react';
import { IAddress } from '../models/IAddress';
import axios, { AxiosResponse } from 'axios';

type IProps = {
  children: React.ReactNode;
};

interface Addresses {
    addresses: IAddress[];
    isLoading: boolean;
    getAddresses: () => Promise<IAddress[]>,
    setAddress: (data: IAddress) => Promise<AxiosResponse>,
    deleteAddress: (id: number) => Promise<AxiosResponse>,
}

interface IAddressContext {
    state: Addresses
    setState: (state: Addresses) => void
}
 
const AddressesInitialData: IAddressContext = {
    state: {
        addresses: [],
        isLoading: false,
        getAddresses: () => {
          return axios.get<IAddress[]>("/api/Address").then((res) => res.data);
        },
        setAddress: (data) => {
          return axios.post<IAddress[]>("/api/Address",data);
        },
        deleteAddress: (id) => {
          return axios.delete<AxiosResponse>(`api/Address/${id}`);
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