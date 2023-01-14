import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import { CardHeader } from "@mui/material";
import Button from "@mui/material/Button";
import OrderContext from "../../contexts/OrderContext";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
export const OrderDelete = () => {
  const navigate = useNavigate();
  const params = useParams();
  const onDeleteHandler = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    const id: number | undefined = params["id"]
      ? parseInt(params["id"])
      : undefined;
    if (id !== undefined) {
      const deleteOrder = async () => {
        const response = await axios.delete(`/api/OrderApi/${id}`);
        navigate("/order");
      };
      deleteOrder();
    }
  };
  const onCancelHandler = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/order");
  };
  return (
    <Card>
      <CardHeader title={"Delete Order"}></CardHeader>
      <CardContent>
        <p>Do you really want to delete?</p>
        <hr />
      </CardContent>
      <CardActions>
        <Button variant="contained" onClick={onDeleteHandler}>
          Delete
        </Button>
        <Button variant="contained" onClick={onCancelHandler}>
          Cancel
        </Button>
      </CardActions>
    </Card>
  );
};
