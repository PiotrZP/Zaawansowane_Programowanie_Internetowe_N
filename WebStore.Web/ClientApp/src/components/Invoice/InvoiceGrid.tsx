import React, { useContext, useEffect } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { Link } from 'react-router-dom';
import { IInvoice } from '../../models/IInvoice';
import InvoiceContext from '../../contexts/InvoiceContext';

type IState = {
    invoices: IInvoice[];
}

export const InvoiceGrid = () => {
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'totalPrice', headerName: 'Total Price', width: 150 },
        { field: 'date', headerName: 'Date Time', width: 130 },
        {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const invoice: IInvoice = params.row;
                return <Link to={`/Invoice/edit/${invoice.id}`} className="btn btn-primary" >Edit</Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const invoice: IInvoice = params.row;
                return <Link to={`/Invoice/delete/${invoice.id}`} className="btn btn-primary">Delete</Link>
            }
        },
    ]
    
    const { getInvoices, state }: any = useContext(InvoiceContext);

    useEffect(() => {
        getInvoices();

    }, []);
    return (
        <div>
            <Link style={{ marginBottom: "5px" }} to={`/Invoice/add`} className="btn btn-primary">Add</Link>
            <div className="invoice-grid">
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={state?.invoices}
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