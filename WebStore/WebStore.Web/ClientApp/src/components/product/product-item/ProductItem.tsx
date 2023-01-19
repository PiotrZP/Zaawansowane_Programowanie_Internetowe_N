import { Snackbar, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import axios from "axios";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "reactstrap";
import { IProduct } from "../../../models/IProduct";

const initialProduct: IProduct = {
  id: 0,
  name: "",
  description: "",
  bytes: [],
  price: 0,
  weight: 0,
  categoryId: 0,
  supplierId: 0,
};

const StoreItem = () => {
  const [product, setProduct] = useState<IProduct>();
  const [message, setMessage] = useState<string>("");
  const isFormValid = useMemo(
    () =>
      Boolean(
        product &&
          product.name &&
          product.description &&
          product.price &&
          product.weight
      ),
    [product]
  );
  const navigate = useNavigate();

  const params = useParams();
  const id = useMemo(
    () => (params["id"] ? parseInt(params["id"]) : undefined),
    [params]
  );

  const getProduct = useCallback(async () => {
    try {
      if (!Boolean(id)) {
        setProduct(initialProduct);
        return;
      }
      const response = await axios.get<IProduct>("/api/productApi/" + id);
      setProduct(response.data);
    } catch {
      // nothing
    }
  }, [id]);

  const onSubmit = useCallback(
    async (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      try {
        const request = {
          id: id && id > 0 ? id : undefined,
          price: product?.price,
          weight: product?.weight,
          categoryId:
            product?.categoryId && product.categoryId > 0 ? id : undefined,
          supplierId:
            product?.supplierId && product.supplierId > 0
              ? product.supplierId
              : undefined,
          name: product?.name,
          description: product?.description,
        };
        id
          ? await axios.put("/api/productApi", request)
          : await axios.post("/api/productApi", request);
        setMessage(id ? "Updated" : "Added");
      } catch {
        setMessage("Error");
      }
    },
    [id, product]
  );

  useEffect(() => {
    getProduct();
  }, [getProduct]);

  if (!product) return <div>loading...</div>;

  return (
    <>
      <Snackbar
        open={Boolean(message)}
        onClose={() => setMessage("")}
        autoHideDuration={4000}
        message={message}
      />
      <Stack
        display="flex"
        alignItems="flex-start"
        direction="column"
        gap="24px"
        component="form"
        onSubmit={onSubmit}
      >
        <Button
          variant="contained"
          color="primary"
          onClick={() => navigate("/product")}
        >
          Back
        </Button>
        <Typography variant="h4">
          {id ? "Edit Product" : "Add Product"}
        </Typography>
        {id && <Typography variant="body1">ID: {id}</Typography>}
        <TextField
          label="Name"
          fullWidth
          required
          value={product.name}
          onChange={(e) => setProduct({ ...product, name: e.target.value })}
        />
        <TextField
          label="Description"
          fullWidth
          required
          value={product.description}
          onChange={(e) =>
            setProduct({ ...product, description: e.target.value })
          }
        />
        <TextField
          label="Price"
          fullWidth
          required
          value={product.price}
          type="number"
          onChange={(e) =>
            setProduct({ ...product, price: parseInt(e.target.value) })
          }
        />
        <TextField
          label="Weight"
          fullWidth
          required
          type="number"
          value={product.weight}
          onChange={(e) =>
            setProduct({ ...product, weight: parseInt(e.target.value) })
          }
        />
        <Button
          type="submit"
          variant="contained"
          color="primary"
          disabled={!isFormValid}
        >
          Confirm
        </Button>
      </Stack>
    </>
  );
};

export default StoreItem;
