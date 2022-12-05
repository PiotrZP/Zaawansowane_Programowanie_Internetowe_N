import React, { useContext, useEffect, useState } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { IAddress } from '../../models/IAddress';
import { Link } from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext';
import { FetchData } from '../FetchData';


export const AddressGrid: React.FC = () => {

    const cols: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'city', headerName: 'City', width: 130 },
        { field: 'zipCode', headerName: 'ZipCode', width: 130 },
        { field: 'street', headerName: 'Street', width: 150 },
        { field: 'country', headerName: 'Country', width: 150 },
        {
            field: 'buildingNumber',
            headerName: 'Building Number',
            type: 'number',
            width: 130
        },
        {
            field: 'apartmentNumber',
            headerName: 'Apartment number',
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
        }
    ];

    const {state, setState} = useContext(AddressContext);

    useEffect(() => {
        // const fetchData = async () => {
        //     let addresses = await state.getAddresses();
        //     setState({
        //         ...state,
        //         addresses: addresses,
        //         isLoading: false,
        //     })
        // }
        // fetchData();
    }, [null])

    if(state.isLoading){
        return(
            <p>Loading...</p>
        )
    }
    return (
        <section>
            <Link style={{ marginBottom: "5px" }} to={'/address/add'} className='btn btn-primary'>Add</Link>
            <div className="address-grid">
                <DataGrid
                    rows={state.addresses}
                    columns={cols}
                    pageSize={5}
                    rowsPerPageOptions={[5]}
                    checkboxSelection={true}
                />
            </div>
        </section>
    )

}    

