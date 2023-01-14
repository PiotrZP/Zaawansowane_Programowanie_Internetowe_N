import React, { useEffect, useState } from "react";
import { IInvoice } from "../../models/IInvoice";
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
export const InvoiceAddOrEditForm = (props: IProps) => {
  const navigate = useNavigate();
  const params = useParams();
  const [state, setState] = useState<IInvoice>({
    id: 0,
    totalPrice: 0,
    date: new Date(),
    stationaryStoreId: 0,
  });
  useEffect(() => {
    const id: number | undefined = params["id"]
      ? parseInt(params["id"])
      : undefined;
    if (id !== undefined) {
      const getInvoices = async () => {
        const response = await axios.get<IInvoice>(`/api/InvoiceApi/${id}`);
        if (response.status == 200) setState({ ...response.data });
      };
      getInvoices();
    }
  }, []);
  const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const name = e.target.name as keyof typeof state;
    setState((state) => ({ ...state, [name]: e.target.value }));
  };
  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const response = await axios.post<IInvoice>("/api/InvoiceApi", state);
    if (response.status == 200)
      setState({
        id: 0,
        totalPrice: 0,
        date: new Date(),
        stationaryStoreId: 0,
      });
    navigate("/invoice");
  };
  const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/invoice");
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
                label="totalPrice"
                name="totalPrice"
                value={state.totalPrice}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="date"
                name="date"
                value={state.date}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="stationaryStoreId"
                name="stationaryStoreId"
                value={state.stationaryStoreId}
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
