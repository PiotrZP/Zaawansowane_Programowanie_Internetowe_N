import React, { useState } from 'react'
import axios from 'axios'
import { IInvoice } from '../models/IInvoice';
const InvoiceContext = React.createContext({});

type IProps = {children: React.ReactNode};
type IState = {invoices: IInvoice[]};

export const InvoiceProvider = (props: IProps) => {
    const [state, setState] = useState<IState>({invoices: []});
    const getInvoices = async () => {
        const response = await axios.get<IInvoice[]>('/api/Invoice');
        setState({invoices: response.data});
    }

    return (
        <InvoiceContext.Provider value = {{
            state,
            getInvoices,
        }}>
            {props.children}
        </InvoiceContext.Provider>
    )
}
export default InvoiceContext;