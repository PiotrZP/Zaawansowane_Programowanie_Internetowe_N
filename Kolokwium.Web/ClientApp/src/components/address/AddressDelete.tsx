import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import { CardHeader } from "@mui/material";
import Button from "@mui/material/Button";
import AddressContext from "../../contexts/AddressContext";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
export const AddressDelete = () => {
  const navigate = useNavigate();
  const params = useParams();
  const onDeleteHandler = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();

    const addressId: number | undefined = params["addressId"]
      ? parseInt(params["addressId"])
      : undefined;
    if (addressId !== undefined) {
      const deleteAddress = async () => {
        const response = await axios.delete(
          `/api/AddressApiContorller/${addressId}`
        );

        navigate("/address");
      };
      deleteAddress();
    }
  };
  const onCancelHandler = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/address");
  };
  return (
    <Card>
      <CardHeader title={"Delete Address"}> </CardHeader>
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
