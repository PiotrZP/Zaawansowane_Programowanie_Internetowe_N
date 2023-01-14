import React, { useState } from 'react'
import axios from 'axios'
import { IOrder } from '../models/IOrder';
const OrderContext = React.createContext({});

type IProps = {children: React.ReactNode};
type IState = {orders: IOrder[]};

export const OrderProvider = (props: IProps) => {
    const [state, setState] = useState<IState>({orders: []});
    const getOrders = async () => {
        const response = await axios.get<IOrder[]>('/api/Order');
        setState({orders: response.data});
    }

    return (
        <OrderContext.Provider value = {{
            state,
            getOrders,
        }}>
            {props.children}
        </OrderContext.Provider>
    )
}
export default OrderContext;