import React, { useState } from "react";
import Invoice from "../../../models/common/Invoice";
import CustomHeader from "../../common/custom-header/CustomHeader";
import CustomTab from "../../common/custom-tab/CustomTab";
import InvoiceAdd from "./components/invoice-add/InvoiceAdd";
import InvoiceDelete from "./components/invoice-delete/InvoiceDelete";
import InvoiceEdit from "./components/invoice-edit/InvoiceEdit";
import InvoiceList from "./components/invoice-list/InvoiceList";
import "./InvoiceView.css";

const InvoiceView = () => {
  const [invoices, setInvoices] = useState<Invoice[]>([]);

  return (
    <div className="invoice-main-container">
      <CustomHeader title="Zamówienia" />
      <CustomTab
        listComponent={<InvoiceList />}
        addComponent={<InvoiceAdd />}
        editComponent={<InvoiceEdit />}
        deleteComponent={<InvoiceDelete />}
      />
    </div>
  );
};
export default InvoiceView;
