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
    id: 0,
    description: "",
    imageBytes: "",
    name: "",
    price: 0,
    weight: 0,
    quantity: 0,
    categoryId: 0,
    supplierId: 0,
  });
  useEffect(() => {
    const id: number | undefined = params["id"]
      ? parseInt(params["id"])
      : undefined;
    if (id !== undefined) {
      const getProduct = async () => {
        const response = await axios.get<IProduct>(`/api/ProductApi/${id}`);
        if (response.status == 200) setState({ ...response.data });
      };
      getProduct();
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
        id: 0,
        description: "",
        imageBytes: "",
        name: "",
        price: 0,
        weight: 0,
        quantity: 0,
        categoryId: 0,
        supplierId: 0,
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
              <input type="hidden" value={state.id} />
              <TextField
                required
                onChange={onInputTextChange}
                label="description"
                name="description"
                value={state.description}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="imageBytes"
                name="imageBytes"
                value={state.imageBytes}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="name"
                name="name"
                value={state.name}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="price"
                name="price"
                value={state.price}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="weight"
                name="weight"
                value={state.weight}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="categoryId"
                name="categoryId"
                value={state.categoryId}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="supplierId"
                name="supplierId"
                value={state.supplierId}
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
