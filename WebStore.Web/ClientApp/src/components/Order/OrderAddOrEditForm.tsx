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
import { IInvoice } from '../../models/IInvoice';
import { IOrder } from '../../models/IOrder';

type IProps = {
    labelName: string
}

export const OrderAddOrEditForm = (props: IProps) => {

    const navigate = useNavigate()
    const params = useParams();

    const [state, setState] = useState<IOrder>({
        id: 0,
        deliveryDate: new Date(),
        orderDate: new Date(),
        totalAmmount: 0,
        trackingNumber: 0,
        invoiceId: 0
    });

    useEffect(() => {
        const id: number | undefined = params["id"] ? parseInt(params["id"]) : undefined;
        if (id !== undefined) {
            const getOrder = async () => {
                const response = await axios.get<IOrder>(`/api/Order/${id}`);
                if (response.status === 200)
                    setState({ ...response.data });
            } 
            getOrder()
        }
    }, []);

    const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const name = e.target.name as keyof typeof state;
        setState(state => ({ ...state, [name]: e.target.value }));

    }

    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const request = {...state, id : state.id&&state.id > 0? state.id : undefined};
        const response = await axios.post<IOrder>("/api/Order", request);
        if (response.status === 200)
            setState({
                id: 0,
                deliveryDate: new Date(),
                orderDate: new Date(),
                totalAmmount: 0,
                trackingNumber: 0,
                invoiceId: 0
            });

        navigate("/Order");
    }

    const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        navigate("/Order");
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
                                label="Delivery Date"
                                name="deliveryDate"
                                type="datetime-local"
                                value={state.deliveryDate}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            />
                              <TextField
                                required
                                onChange={onInputTextChange}
                                label="Order Date"
                                name="orderDate"
                                type="datetime-local"
                                value={state.orderDate}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            />
                               <TextField
                                required
                                onChange={onInputTextChange}
                                label="Total Ammount"
                                name="totalAmmount"
                                type="number"
                                value={state.totalAmmount}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            />
                              <TextField
                                required
                                onChange={onInputTextChange}
                                label="Tracking Number"
                                name="trackingNumber"
                                type="number"
                                value={state.trackingNumber}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            /> 
                            <TextField
                            required
                            onChange={onInputTextChange}
                            label="Invoice ID"
                            name="invoiceId"
                            type="number"
                            value={state.invoiceId}
                            InputLabelProps={{
                                shrink: true,
                            }}
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