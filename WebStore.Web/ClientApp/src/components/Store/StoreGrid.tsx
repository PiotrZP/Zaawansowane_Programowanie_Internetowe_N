import React, { useContext, useEffect } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { IStore } from "../../models/IStore";
import { Link } from "react-router-dom";
import StoreContext from "../../contexts/StoreContext";
type IState = {
  stores: IStore[];
};
export const StoreGrid = () => {
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "name", headerName: "Name", width: 80 },
    //{ field: "date", headerName: "Date", width: 110 },
    // { field: "stationaryStoreId", headerName: "StationaryStoreId", width: 140 },
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
        const store: IStore = params.row;
        return (
          <Link to={`/store/edit/${store.id}`} className="btn btn-primary">
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
        const store: IStore = params.row;
        return (
          <Link to={`/store/delete/${store.id}`} className="btn btn-primary">
            Delete
          </Link>
        );
      },
    },
  ];
  const { getStores, state }: any = useContext(StoreContext);
  useEffect(() => {
    getStores();
  }, []);
  return (
    <div>
      <Link
        style={{ marginBottom: "5px" }}
        to={`/store/add`}
        className="btn btn-primary"
      >
        Add
      </Link>
      <div className="store-grid">
        <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            rows={state.stores}
            columns={columns}
            //pageSize={5}
            //rowsPerPageOptions={[5]}
            //checkboxSelection
          />
        </div>
      </div>
    </div>
  );
};
