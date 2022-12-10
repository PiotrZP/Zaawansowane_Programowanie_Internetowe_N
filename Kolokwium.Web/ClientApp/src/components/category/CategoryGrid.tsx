import React, { createContext, useContext, useEffect } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { ICategory } from "../../models/ICategory";
import { Link } from "react-router-dom";
import CategoryContext from "../../contexts/CategoryContext";
import Checkbox from "@mui/material/Checkbox"

export const CategoryGrid = () => {
   
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "name", headerName: "Name", width: 150 },
    { field: "tag", headerName: "Tag", width: 150 },
    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const categories: ICategory = params.row;
        return (
          <Link
            to={`/category/edit/${categories.id}`}
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
        const categories: ICategory = params.row;
        return (
          <Link
            to={`/category/delete/${categories.id}`}
            className="btn btn-primary"
          >
            Delete
          </Link>
        );
      },
    },
  ];
  // use any when {} 
  const { getCategories, state}: any = useContext(CategoryContext);

  useEffect(() => {
    getCategories();
  }, []);
  // conversion
  const categories = state.categories;
 
  // const arrayOfObjects = [categories];
  console.log(categories,"??")
  return (
    <div>
      <Link
        style={{ marginBottom: "5px" }}
        to={`/category/add`}
        className="btn btn-primary"
      >
        Add
      </Link>
      <div className="category-grid">
        <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            getRowId={(row) => row?.id}
            rows={categories}
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