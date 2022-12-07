import React, { useContext, useEffect, useState } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { IAddress } from '../../models/IAddress';
import { Link } from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext';
import { Backdrop, CircularProgress } from '@mui/material';
import { Col, Row } from 'reactstrap';

export const AddressGrid: React.FC = () => {

    const cols: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'city', headerName: 'City', width: 250 },
        { field: 'postCode', headerName: 'Post code', width: 130 },
        { field: 'StreetName', headerName: 'Street Name', width: 250 },
        { field: 'StreetNumber', headerName: 'Street Number', width: 250 },
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
        state.getAddresses().then((res)=>{
            setState({
                ...state,
                addresses: res,
                isLoading: false,
            })
        })
    }, [null])
    
    if(state.isLoading){
        return(
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={true}
            >
                <CircularProgress color='inherit'/>
            </Backdrop>
        )
    }else{
        return (
            <Row>
                <Col>
                    <Link style={{ marginBottom: "5px" }} to={'/address/add'} className='btn btn-primary'>Add</Link>
                    <div className="address-grid">
                        <DataGrid
                            rows={state.addresses}
                            columns={cols}
                            pageSize={5}
                            rowsPerPageOptions={[5]}
                            checkboxSelection={true}
                            autoHeight
                        />
                    </div>
                </Col>
            </Row>
        )
    }

}    

