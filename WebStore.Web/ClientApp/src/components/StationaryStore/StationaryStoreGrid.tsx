import React, { useContext, useEffect } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { IAddress } from '../../models/IAddress';
import { Link } from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext';
import { IStationaryStore } from '../../models/IStationaryStore';
import StationaryStoreContext from '../../contexts/StationaryStoreContext';

type IState = {
    stationaryStores: IStationaryStore[];
}

export const StationaryStoreGrid = () => {
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'name', headerName: 'Name', width: 150 },
        {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const stationaryStores: IStationaryStore = params.row;
                return <Link to={`/stationaryStore/edit/${stationaryStores.id}`} className="btn btn-primary">Edit</Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const stationaryStore: IStationaryStore = params.row;
                return <Link to={`/stationaryStore/delete/${stationaryStore.id}`} className="btn btn-primary">Delete</Link>
            }
        },
    ]
    
    const { getStationaryStores, state }: any = useContext(StationaryStoreContext);

    useEffect(() => {
        getStationaryStores();

    }, []);
    return (
        <div>
            <Link style={{ marginBottom: "5px" }} to={`/stationaryStore/add`} className="btn btn-primary">Add</Link>
            <div className="stationaryStore-grid">
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={state.stationaryStores}
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