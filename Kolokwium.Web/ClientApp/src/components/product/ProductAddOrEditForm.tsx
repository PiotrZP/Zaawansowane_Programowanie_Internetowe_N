import React, { useEffect, useState } from "react";
import { IProduct } from "../../models/IProduct";
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
export const ProductAddOrEditForm = (props: IProps) => {
  const navigate = useNavigate();
  const params = useParams();
  const [state, setState] = useState<IProduct>({
    productId: 0,
    name: "",
    description: "",
    weight: 0,
    quantity: 0,
    price: 0,
    imageBytes: [],
  });
  useEffect(() => {
    const productId: number | undefined = params["productId"]
      ? parseInt(params["productId"])
      : undefined;
    if (productId !== undefined) {
      const getAddress = async () => {
        const response = await axios.get<IProduct>(
          `/api/ProductApi${productId}`
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
    const response = await axios.post<IProduct>("/api/ProductApi", state);
    if (response.status == 200)
      setState({
        productId: 0,
        name: "",
        description: "",
        weight: 0,
        quantity: 0,
        price: 0,
        imageBytes: [],
      });
    navigate("/product");
  };
  const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/product");
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
              <input type="hidden" value={state.productId} />
              <TextField
                required
                onChange={onInputTextChange}
                label="Name"
                name="name"
                value={state.name}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Description"
                name="description"
                value={state.description}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Weight"
                name="weight"
                value={state.weight}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Quantity"
                name="quantity"
                value={state.quantity}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Price"
                name="price"
                value={state.price}
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
