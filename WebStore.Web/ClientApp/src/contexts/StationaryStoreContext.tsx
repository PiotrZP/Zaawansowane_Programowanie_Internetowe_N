import React, { useState } from 'react'
import axios from 'axios'
import { IStationaryStore } from '../models/IStationaryStore';
const StationaryStoreContext = React.createContext({});

type IProps = {children: React.ReactNode};
type IState = {stationaryStores: IStationaryStore[]};

export const StationaryStoreProvider = (props: IProps) => {
    const [state, setState] = useState<IState>({stationaryStores: []});
    const getStationaryStores = async () => {
        const response = await axios.get<IStationaryStore[]>('/api/StationaryStore');
        setState({stationaryStores: response.data});
    }

    return (
        <StationaryStoreContext.Provider value = {{
            state,
            getStationaryStores,
        }}>
            {props.children}
        </StationaryStoreContext.Provider>
    )
}
export default StationaryStoreContext;