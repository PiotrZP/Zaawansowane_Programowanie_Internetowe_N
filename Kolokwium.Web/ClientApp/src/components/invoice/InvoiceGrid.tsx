import React, { createContext, useContext, useEffect } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { IInvoice } from "../../models/IInvoice";
import { Link } from "react-router-dom";
import InvoiceContext from "../../contexts/InvoiceContext";

export const InvoiceGrid = () => {
   
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "totalPrice", headerName: "Total Price", width: 150 },
    { field: "invoiceDate", headerName: "Invoice Date", width: 150 },
    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const invoices: IInvoice = params.row;
        return (
          <Link
            to={`/invoice/edit/${invoices.id}`}
            className="btn btn-primary"
          >
            Edit
          </Link>
        );
      },
    },
    {
      field: "delete",
      headerName: "Delete",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const invoices: IInvoice = params.row;
        return (
          <Link
            to={`/invoice/delete/${invoices.id}`}
            className="btn btn-primary"
          >
            Delete
          </Link>
        );
      },
    },
  ];
  // use any when {}
  const { getInvoices, state}: any = useContext(InvoiceContext);

  useEffect(() => {
    getInvoices();
  }, []);
  // check
  const invoices = state.invoices || [];

  return (
    <div>
      <Link
        style={{ marginBottom: "5px" }}
        to={`/invoice/add`}
        className="btn btn-primary"
      >
        Add
      </Link>
      <div className="invoice-grid">
        <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            getRowId={(row) => row.id}
            rows={invoices}
            columns={columns}
            pageSize={5}
            rowsPerPageOptions={[5]}
            checkboxSelection
          />
        </div>
      </div>
    </div>
  );
};