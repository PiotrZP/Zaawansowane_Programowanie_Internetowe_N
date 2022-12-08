import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import { CardHeader } from "@mui/material";
import Button from "@mui/material/Button";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
export const ProductDelete = () => {
  const navigate = useNavigate();
  const params = useParams();
  const onDeleteHandler = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();

    const productId: number | undefined = params["productId"]
      ? parseInt(params["productId"])
      : undefined;
    if (productId !== undefined) {
      const deleteAddress = async () => {
        const response = await axios.delete(
          `/api/ProductApi/${productId}`
        );

        navigate("/product");
      };
      deleteAddress();
    }
  };
  const onCancelHandler = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/product");
  };
  return (
    <Card>
      <CardHeader title={"Delete product"}> </CardHeader>
      <CardContent>
        <p>Do you really want to delete?</p>
        <hr />{" "}
      </CardContent>{" "}
      <CardActions>
        <Button variant="contained" onClick={onDeleteHandler}>
          Delete
        </Button>
        <Button variant="contained" onClick={onCancelHandler}>
          Cancel
        </Button>{" "}
      </CardActions>
    </Card>
  );
};