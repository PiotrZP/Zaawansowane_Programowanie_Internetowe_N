import React, { useContext, useEffect } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { IAddress } from '../../models/IAddress';
import { Link } from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext';

type IState = {
    addresses: IAddress[];
}

export const AddressGrid = () => {
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'streetAdress', headerName: 'Street Adress', width: 150 },
        { field: 'city', headerName: 'City', width: 130 },
        { field: 'state', headerName: 'State', width: 130 },
        { field: 'zipCode', headerName: 'ZipCode', width: 130 },
        {
            field: 'stationaryStoreId',
            headerName: 'Stationary Store Id',
            type: 'number',
            width: 150,
        },
        {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const address: IAddress = params.row;
                return <Link to={`/address/edit/${address.id}`} className="btn btn-primary" >Edit</Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const address: IAddress = params.row;
                return <Link to={`/address/delete/${address.id}`} className="btn btn-primary">Delete</Link>
            }
        },
    ]
    
    const { getAddresses, state }: any = useContext(AddressContext);
    console.log('adres', state.addresses);

    useEffect(() => {
        getAddresses();

    }, []);
    return (
        <div>
            <Link style={{ marginBottom: "5px" }} to={`/address/add`} className="btn btn-primary">Add</Link>
            <div className="address-grid">
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={state.addresses}
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