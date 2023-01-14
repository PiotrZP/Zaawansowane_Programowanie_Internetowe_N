import React, { useState } from "react";
import axios from "axios";
import { IOrder } from "../models/IOrder";
const OrderContext = React.createContext({});
type IProps = { children: React.ReactNode };
type IState = {
  order: IOrder[];
};
export const OrderProvider = (props: IProps) => {
  const [state, setState] = useState<IState>({ order: [] });
  const getOrders = async () => {
    const response = await axios.get<IOrder[]>("/api/OrderApi");
    setState({ order: response.data });
  };
  return (
    <OrderContext.Provider
      value={{
        state,
        getOrders,
      }}
    >
      {props.children}
    </OrderContext.Provider>
  );
};
export default OrderContext;
