import React, {
    useEffect,
    useState,
    useContext
} from 'react'
import {
    IAddress
} from '../../models/IAddress';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import {
    CardHeader
} from '@mui/material';
import {
    useNavigate,
    useParams
} from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext';
import axios from 'axios';

type IProps = {
    labelName: string
}

export const AddressAddOrEditForm = (props: IProps) => {
    const navigate = useNavigate()
    const params = useParams();

    const [address, setAddress] = useState<IAddress>({ 
        id: 0,
        buildingNumber: 0,
        city: "",
        country: "",
        streetName: "",
        postCode: "",
        appartmentNumber: 0
    });
    const {state, setState} = useContext(AddressContext);
    
    useEffect(() => {
        const id: number | undefined = params["id"] ? parseInt(params["id"]) : undefined;
        if (id !== undefined) {
            const fetchData = async () => {
                let fetchedAddress = await state.getAddressById(id);
                setState({
                    ...state,
                    isLoading: false,
                })
                setAddress(fetchedAddress)
            }
            fetchData();
        }
    }, [null])

    const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => { 
        const name = e.target.name as keyof typeof address;
        setAddress(address => ({ ...address, [name]: e.target.value }));
    }

    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const response = await state.setAddress(address)
        if(response.status == 200){
            setAddress({
                id: 0,
                buildingNumber: 0,
                city: "",
                country: "",
                streetName: "",
                postCode: "",
                appartmentNumber: 0
            });
            navigate("/address");
        }
    }

    const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => { 
        e.preventDefault();
        navigate("/address");
    }

    return(
        <div className="form-container">
            <Box
                component="form" 
                sx={{ '.MuiTextField-root': { m: 1, width: '25ch' }, }}
                noValidate
                autoComplete="off"
                onSubmit={onSubmit}
            >
                <Card>
                    <CardHeader title={props.labelName} />
                    <CardContent>
                        <div>
                            <input type="hidden" value={address.id} />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="City"
                                name="city"
                                value={address.city}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Zip code"
                                name="postCode"
                                value={address.postCode}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Street"
                                name="streetName"
                                value={address.streetName}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Country"
                                name="country"
                                value={address.country}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Building number"
                                name="buildingNumber"
                                value={address.buildingNumber}
                                InputLabelProps={{
                                    shrink: true, 
                                }}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Appartment number"
                                name="appartmentNumber"
                                value={address.appartmentNumber}
                                InputLabelProps={{
                                    shrink: true, 
                                }}
                            />
                        </div>
                        <hr/>
                    </CardContent>
                    <CardActions>
                        <Button type="submit" variant="contained" endIcon={<SaveIcon/>}>Save</Button>
                        <Button type="button" variant="contained" onClick={onCancel} endIcon={<CancelIcon/>}>Cancel</Button>
                    </CardActions>
                </Card>
            </Box>
        </div>
    )
}