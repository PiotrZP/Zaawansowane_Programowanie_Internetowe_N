import React, { useState } from "react";
import axios from "axios";
import { IStore } from "../models/IStore";
const StoreContext = React.createContext({});
type IProps = { children: React.ReactNode };
type IState = {
  stores: IStore[];
};
export const StoreProvider = (props: IProps) => {
  const [state, setState] = useState<IState>({ stores: [] });
  const getStores = async () => {
    const response = await axios.get<IStore[]>("/api/StoreApi");
    setState({ stores: response.data });
  };
  return (
    <StoreContext.Provider
      value={{
        state,
        getStores,
      }}
    >
      {props.children}
    </StoreContext.Provider>
  );
};
export default StoreContext;
