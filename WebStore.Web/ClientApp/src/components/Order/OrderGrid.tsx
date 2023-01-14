import React, { useContext, useEffect } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { Link } from 'react-router-dom';
import { IOrder } from '../../models/IOrder';
import OrderContext from '../../contexts/OrderContext';

type IState = {
    orders: IOrder[];
}

export const OrderGrid = () => {
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'deliveryDate', headerName: 'Delivery Date', width: 150 },
        { field: 'orderDate', headerName: 'Order Date', width: 130 },
        { field: 'totalAmmount', headerName: 'Total Ammount', width: 130 },
        { field: 'trackingNumber', headerName: 'Tracking Number', width: 130 },
        { field: 'invoiceId', headerName: 'Invoice Id', width: 130 },
       {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const order: IOrder = params.row;
                return <Link to={`/Order/edit/${order.id}`} className="btn btn-primary" >Edit</Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const order: IOrder = params.row;
                return <Link to={`/Order/delete/${order.id}`} className="btn btn-primary">Delete</Link>
            }
        },
    ]
    
    const { getOrders, state }: any = useContext(OrderContext);

    useEffect(() => {
        getOrders();

    }, []);
    return (
        <div>
            <Link style={{ marginBottom: "5px" }} to={`/Order/add`} className="btn btn-primary">Add</Link>
            <div className="Order-grid">
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={state?.orders}
                        columns={columns}
                        pageSize={5}
                        rowsPerPageOptions={[5]}
                        checkboxSelection
                    />
                </div>
            </div>
        </div>
    )
}