import React, { useContext, useEffect } from "react";
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
    { field: "description", headerName: "Description", width: 80 },
    { field: "imageBytes", headerName: "ImageBytes", width: 110 },
    { field: "name", headerName: "Name", width: 140 },
    { field: "price", headerName: "Price", width: 170 },
    { field: "weight", headerName: "Weight", width: 200 },
    { field: "quantity", headerName: "Quantity", width: 230 },
    { field: "categoryId", headerName: "CategoryId", width: 260 },
    { field: "supplierId", headerName: "SupplierId", width: 290 },
    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const product: IProduct = params.row;
        return (
          <Link to={`/product/edit/${product.id}`} className="btn btn-primary">
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
        const product: IProduct = params.row;
        return (
          <Link
            to={`/product/delete/${product.id}`}
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
            rows={state.product}
            columns={columns}
            // pageSize={5}
            // rowsPerPageOptions={[5]}
            // checkboxSelection
          />
        </div>
      </div>
    </div>
  );
};
