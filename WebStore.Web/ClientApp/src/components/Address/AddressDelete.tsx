import React, { useContext } from 'react'
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import {
    CardHeader
} from '@mui/material';
import Button from '@mui/material/Button';
import {
    useNavigate,
    useParams
} from 'react-router-dom';
import axios from 'axios';
import AddressContext from '../../contexts/AddressContext';

export const AddressDelete: React.FC = () => {
    const navigate = useNavigate()
    const params = useParams();
    const { state, setState } = useContext(AddressContext);

    const onDelete = async (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        const id: number | undefined = params["id"] ? parseInt(params["id"]) : undefined;
        if(id !== undefined){
            const response = await state.deleteAddress(id);
            if(response.status === 200){
                navigate("/address");
            }
        }
    }

    const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        navigate('/address');
    }

    return (
        <Card>
            <CardHeader title="Delete Address"/>
            <CardContent>
                <p>
                    Do you really want to delete?
                </p>
                <hr/>
            </CardContent>
            <CardActions>
                <Button variant="contained" onClick={onDelete}>Delete</Button>
                <Button variant="contained" onClick={onCancel}>Cancel</Button>
            </CardActions>
        </Card>
    )
}
