import React, { useEffect, useState } from "react";
import { IAddress } from "../../models/IAddress";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Cancel";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import { CardHeader } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
type IProps = {
  labelName: string;
};
export const AddressAddOrEditForm = (props: IProps) => {
  const navigate = useNavigate();
  const params = useParams();
  const [state, setState] = useState<IAddress>({
    addressId: 0,
    city: "",
    streetName: "",
    postCode: "",
    streetNumber: 0,
  });
  useEffect(() => {
    const addressId: number | undefined = params["addressId"]
      ? parseInt(params["addressId"])
      : undefined;
    if (addressId !== undefined) {
      const getAddress = async () => {
        const response = await axios.get<IAddress>(
          `/api/AddressApiContorller/${addressId}`
        );
        if (response.status == 200) setState({ ...response.data });
      };
      getAddress();
    }
  }, []);
  const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const name = e.target.name as keyof typeof state;
    setState((state) => ({ ...state, [name]: e.target.value }));
  };
  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const response = await axios.post<IAddress>(
      "/api/AddressApiContorller",
      state
    );
    if (response.status == 200)
      setState({
        addressId: 0,
        city: "",
        streetName: "",
        postCode: "",
        streetNumber: 0,
      });
    navigate("/address");
  };
  const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/address");
  };
  return (
    <div className="form-container">
      <Box
        component="form"
        sx={{
          ".MuiTextField-root": { m: 1, width: "25ch" },
        }}
        noValidate
        autoComplete="off"
        onSubmit={onSubmit}
      >
        <Card>
          <CardHeader title={props.labelName}></CardHeader>
          <CardContent>
            <div>
              <input type="hidden" value={state.addressId} />
              <TextField
                required
                onChange={onInputTextChange}
                label="City"
                name="city"
                value={state.city}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Zip code"
                name="zipCode"
                value={state.postCode}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Street"
                name="street"
                value={state.streetName}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Street Number"
                name="streetNumber"
                value={state.streetNumber}
              />
            </div>
            <hr />
          </CardContent>
          <CardActions>
            <Button type="submit" variant="contained" endIcon={<SaveIcon />}>
              {" "}
              Save{" "}
            </Button>
            <Button
              type="button"
              variant="contained"
              onClick={onCancel}
              endIcon={<CancelIcon />}
            >
              {" "}
              Cancel
            </Button>
          </CardActions>
        </Card>
      </Box>
    </div>
  );
};
