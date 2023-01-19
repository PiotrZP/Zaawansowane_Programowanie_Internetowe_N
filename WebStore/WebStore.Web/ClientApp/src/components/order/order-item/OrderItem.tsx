import { Snackbar, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import axios from "axios";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "reactstrap";
import { IOrder } from "../../../models/IOrder";

const initialOrder: IOrder = {
  id: 0,
  totalAmount: 0,
  trackingNumber: 0,
  deliveryDate: new Date(),
  orderDate: new Date(),
  stationaryStoreId: 0,
  invoiceid: 0,
};

const StoreItem = () => {
  const [order, setOrder] = useState<IOrder>();
  const [message, setMessage] = useState<string>("");
  const isFormValid = useMemo(
    () =>
      Boolean(
        order &&
          order.totalAmount &&
          order.trackingNumber &&
          order.deliveryDate &&
          order.orderDate &&
          order.stationaryStoreId &&
          order.invoiceid
      ),
    [order]
  );
  const navigate = useNavigate();

  const params = useParams();
  const id = useMemo(
    () => (params["id"] ? parseInt(params["id"]) : undefined),
    [params]
  );

  const getOrder = useCallback(async () => {
    try {
      if (!Boolean(id)) {
        setOrder(initialOrder);
        return;
      }
      const response = await axios.get<IOrder>("/api/orderApi/" + id);
      setOrder(response.data);
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
          totalAmount: order?.totalAmount,
          trackingNumber: order?.trackingNumber,
          deliveryDate: new Date(),
          orderDate: new Date(),
          stationaryStoreId: order?.stationaryStoreId,
          invoiceid: order?.invoiceid,
        };
        id
          ? await axios.put("/api/orderApi", request)
          : await axios.post("/api/orderApi", request);
        setMessage(id ? "Updated" : "Added");
      } catch {
        setMessage("Error");
      }
    },
    [
      id,
      order?.invoiceid,
      order?.stationaryStoreId,
      order?.totalAmount,
      order?.trackingNumber,
    ]
  );

  useEffect(() => {
    getOrder();
  }, [getOrder]);

  if (!order) return <div>loading...</div>;

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
          onClick={() => navigate("/order")}
        >
          Back
        </Button>
        <Typography variant="h4">{id ? "Edit Order" : "Add Order"}</Typography>
        {id && <Typography variant="body1">ID: {id}</Typography>}
        <TextField
          label="Total amount"
          fullWidth
          required
          type="number"
          value={order.totalAmount}
          onChange={(e) =>
            setOrder({ ...order, totalAmount: parseInt(e.target.value) })
          }
        />
        <TextField
          label="Tracking number"
          fullWidth
          required
          type="number"
          value={order.trackingNumber}
          onChange={(e) =>
            setOrder({ ...order, trackingNumber: parseInt(e.target.value) })
          }
        />
        <TextField
          label="Store id"
          fullWidth
          required
          type="text"
          value={order.stationaryStoreId}
          onChange={(e) =>
            setOrder({ ...order, stationaryStoreId: parseInt(e.target.value) })
          }
        />
        <TextField
          label="Invoice id"
          fullWidth
          required
          type="text"
          value={order.invoiceid}
          onChange={(e) =>
            setOrder({ ...order, invoiceid: parseInt(e.target.value) })
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
