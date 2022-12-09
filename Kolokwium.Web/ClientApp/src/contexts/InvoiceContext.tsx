import React, { useState } from "react";
import axios from "axios";
import { IInvoice } from "../models/IInvoice";

const InvoiceContext = React.createContext({});

export const InvoiceProvider = ({ children }: { children: React.ReactNode }) => {
  const [state, setState] = useState<{ invoices: IInvoice[] }>({ invoices: [] });

  const getInvoices = async () => {
    const response = await axios.get<IInvoice[]>("/api/InvoiceApi");
    setState({ invoices: response.data });
  };

  return (
    <InvoiceContext.Provider
      value={{
        state,
        getInvoices,
      }}
    >
      {children}
    </InvoiceContext.Provider>
  );
};

export default InvoiceContext;



