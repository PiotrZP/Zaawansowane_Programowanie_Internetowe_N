import React, { useContext, useEffect } from "react";
import { DataGrid, GridColDef, GridRenderCellParams } from "@mui/x-data-grid";
import { IOrder } from "../../models/IOrder";
import { Link } from "react-router-dom";
import OrderContext from "../../contexts/OrderContext";
// type IState = {
//   orders: IOrder[];
// };
export const OrderGrid = () => {
  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "deliveryDate", headerName: "DeliveryDate", width: 80 },
    { field: "orderDate", headerName: "OrderDate", width: 110 },
    { field: "totalAmount", headerName: "TotalAmount", width: 140 },
    { field: "trackingNumber", headerName: "TrackingNumber", width: 170 },
    { field: "invoiceId", headerName: "InvoiceId", width: 200 },
    { field: "customerId", headerName: "CustomerId", width: 230 },
    { field: "stationaryStoreId", headerName: "StationaryStoreId", width: 260 },

    {
      field: "edit",
      headerName: "Edit",
      sortable: false,
      renderCell: (params: GridRenderCellParams) => {
        const order: IOrder = params.row;
        return (
          <Link to={`/order/edit/${order.id}`} className="btn btn-primary">
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
        const order: IOrder = params.row;
        return (
          <Link to={`/order/delete/${order.id}`} className="btn btn-primary">
            Delete
          </Link>
        );
      },
    },
  ];
  const { getOrders, state }: any = useContext(OrderContext);
  useEffect(() => {
    getOrders();
  }, []);
  return (
    <div>
      <Link
        style={{ marginBottom: "5px" }}
        to={`/order/add`}
        className="btn btn-primary"
      >
        Add
      </Link>
      <div className="order-grid">
        <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            rows={state.order}
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
