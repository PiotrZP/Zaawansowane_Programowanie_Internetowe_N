import {
  IconButton,
  Paper,
  Snackbar,
  TableBody,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import axios from "axios";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import DeleteIcon from "@mui/icons-material/Delete";
import Edit from "@mui/icons-material/Edit";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router";
import { IProduct } from "../../../models/IProduct";
import { PlCell, PlMainContainer } from "./ProductListStyles";

const ProductList = () => {
  const [products, setProducts] = useState<IProduct[]>([]);
  const [message, setMessage] = useState<string>("");
  const navigate = useNavigate();

  const getProducts = useCallback(async (showMessage?: boolean) => {
    try {
      const response = await axios.get<IProduct[]>("/api/productApi");
      setProducts(response.data);
      showMessage && setMessage("Data updated");
    } catch {
      setMessage("Error");
    }
  }, []);

  const deleteProduct = useCallback(
    async (storeId: number) => {
      try {
        await axios.delete("/api/productApi/" + storeId);
        setMessage("Store deleted");
        await getProducts();
      } catch {
        setMessage("Nie udało się usunąć store");
      }
    },
    [getProducts]
  );

  useEffect(() => {
    getProducts(true);
  }, [getProducts]);

  const sorted = useMemo(
    () => products.sort((a, b) => a.id - b.id),
    [products]
  );

  return (
    <PlMainContainer>
      <Snackbar
        open={Boolean(message)}
        onClose={() => setMessage("")}
        autoHideDuration={4000}
        message={message}
      />
      <Button
        color="primary"
        variant="container"
        onClick={() => navigate("/product/add/")}
      >
        Add
      </Button>
      <TableContainer component={Paper} elevation={12}>
        <Table>
          <TableHead>
            <TableRow sx={{ display: "flex" }}>
              <PlCell>Id</PlCell>
              <PlCell sx={{ width: "100%" }}>Name</PlCell>
              <PlCell sx={{ width: "100%" }}>Description</PlCell>
              <PlCell>Price</PlCell>
              <PlCell>Weight</PlCell>
              <PlCell>Delete</PlCell>
              <PlCell>Edit</PlCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {sorted.map((product) => (
              <TableRow sx={{ display: "flex" }}>
                <PlCell>{product.id}</PlCell>
                <PlCell sx={{ width: "100%" }}>{product.name}</PlCell>
                <PlCell sx={{ width: "100%" }}>{product.description}</PlCell>
                <PlCell>{product.price}</PlCell>
                <PlCell>{product.weight}</PlCell>
                <PlCell>
                  <IconButton onClick={() => deleteProduct(product.id)}>
                    <DeleteIcon />
                  </IconButton>
                </PlCell>
                <PlCell>
                  <IconButton
                    onClick={() => navigate("/product/edit/" + product.id)}
                  >
                    <Edit />
                  </IconButton>
                </PlCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </PlMainContainer>
  );
};

export default ProductList;
