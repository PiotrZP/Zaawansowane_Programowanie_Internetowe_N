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
    getAddressById: (id: number) => Promise<IAddress>,
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
        isLoading: true,
        getAddresses: () => {
          return axios.get<IAddress[]>("/api/AddressApi").then((res) => res.data);
        },
        setAddress: (data) => {
          return axios.post<IAddress[]>("/api/AddressApi",data);
        },
        deleteAddress: (id) => {
          return axios.delete<AxiosResponse>(`api/AddressApi/${id}`);
        },
        getAddressById: (id) => {
          return axios.get<IAddress>("/api/AddressApi/"+id).then((res) => res.data);
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
    <AddressContext.Provider value={contextValue}>
      {props.children}
    </AddressContext.Provider>
  );
};