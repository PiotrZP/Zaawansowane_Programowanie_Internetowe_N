import React, { useContext, useEffect, useState } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { IInvoice } from "../../models/IInvoice";
import { Link } from "react-router-dom";
import InvoiceContext from "../../contexts/InvoiceContext";
type IState = {
  invoices: IInvoice[];
};
export const InvoiceGrid = () => {
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "totalPrice", headerName: "TotalPrice", width: 80 },
    { field: "date", headerName: "Date", width: 110 },
    { field: "stationaryStoreId", headerName: "StationaryStoreId", width: 140 },
    // { field: "street", headerName: "Street", width: 150 },
    // { field: "country", headerName: "Country", width: 100 },
    // {
    //   field: "buildingNumber",
    //   headerName: "Building number",
    //   type: "number",
    //   width: 130,
    // },
    // {
    //   field: "apartmentNumber",
    //   headerName: "Apartment number",
    //   type: "number",
    //   width: 150,
    // },
    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const invoice: IInvoice = params.row;
        return (
          <Link to={`/invoice/edit/${invoice.id}`} className="btn btn-primary">
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
        const invoice: IInvoice = params.row;
        return (
          <Link
            to={`/invoice/delete/${invoice.id}`}
            className="btn btn-primary"
          >
            Delete
          </Link>
        );
      },
    },
  ];
  const { getInvoices, state }: any = useContext(InvoiceContext);
  useEffect(() => {
    getInvoices();
  }, []);
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
            rows={state.invoices}
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
