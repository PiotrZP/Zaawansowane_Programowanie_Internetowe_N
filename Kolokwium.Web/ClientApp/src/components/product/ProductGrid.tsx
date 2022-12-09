import React, { useContext, useEffect, useState } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { IProduct } from "../../models/IProduct";
import { Link } from "react-router-dom";
import ProductContext from "../../contexts/ProductContext";
type IState = {
  products: IProduct[];
};
export const ProductGrid = () => {
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "name", headerName: "Name", width: 130 },
    { field: "description", headerName: "Description", width: 130 },
    { field: "weight", headerName: "Weight", width: 150 },
    { field: "quantity", headerName: "Quantity", width: 150 },
    { field: "price", headerName: "Price", width: 150 },
    { field: "supplier", headerName: "Supplier", width: 150 },
    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const products: IProduct = params.row;
        return (
          <Link
            to={`/product/edit/${products.id}`}
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
        const products: IProduct = params.row;
        return (
          <Link
            to={`/product/delete/${products.id}`}
            className="btn btn-primary"
          >
            Delete
          </Link>
        );
      },
    },
  ];
  const { getProducts, state }: any = useContext(ProductContext);
  useEffect(() => {
    getProducts();
  }, []);
  return (
    <div>
      <Link
        style={{ marginBottom: "5px" }}
        to={`/product/add`}
        className="btn btn-primary"
      >
        Add
      </Link>
      <div className="product-grid">
        <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            getRowId={(row) => row.id}
            rows={state.products}
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
