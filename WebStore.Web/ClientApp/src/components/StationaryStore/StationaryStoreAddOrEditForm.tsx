import React, { useEffect, useState } from 'react'
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import { CardHeader } from '@mui/material';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';
import { IStationaryStore } from '../../models/IStationaryStore';

type IProps = {
    labelName: string
}

export const StationaryStoreAddOrEditForm = (props: IProps) => {

    const navigate = useNavigate()
    const params = useParams();

    const [state, setState] = useState<IStationaryStore>({
        id: 0,
        name: ''
    });

    useEffect(() => {
        const id: number | undefined = params["id"] ? parseInt(params["id"]) : undefined;
        if (id !== undefined) {
            const getStationaryStore = async () => {
                const response = await axios.get<IStationaryStore>(`/api/StationaryStore/${id}`);
                if (response.status === 200)
                    setState({ ...response.data });
            } 
            getStationaryStore()
        }
    }, []);

    const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const name = e.target.name as keyof typeof state;
        setState(state => ({ ...state, [name]: e.target.value }));

    }

    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const request = {...state, id : state.id&&state.id > 0? state.id : undefined};
        const response = await axios.post<IStationaryStore>("/api/StationaryStore", request);
        if (response.status === 200)
            setState({
                id: 0,
                name: ''
            });

        navigate("/StationaryStore");
    }

    const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        navigate("/StationaryStore");
    }

    return (
        <div className="form-container">
            <Box
                component="form"
                sx={{
                    '.MuiTextField-root': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="off"
                onSubmit={onSubmit}
            >
                <Card>
                    <CardHeader title={props.labelName} >
                    </CardHeader>
                    <CardContent>
                        <div>
                            <input type="hidden" value={state.id} />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Name"
                                name="name"
                                value={state.name}
                            />
                        </div>
                        <hr />
                    </CardContent>
                    <CardActions>
                        <Button type="submit" variant="contained" endIcon={<SaveIcon />}> Save </Button>
                        <Button type="button" variant="contained" onClick={onCancel} endIcon={<CancelIcon />}> Cancel
                        </Button>
                    </CardActions>
                </Card>
            </Box>
        </div>
    );
}