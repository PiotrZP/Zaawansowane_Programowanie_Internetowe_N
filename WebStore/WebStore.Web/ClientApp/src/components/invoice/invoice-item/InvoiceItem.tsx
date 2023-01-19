import { Snackbar, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import axios from "axios";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "reactstrap";
import { IInvoice } from "../../../models/IInvoice";

const initialInvoice: IInvoice = {
  id: 0,
  totalPrice: 0,
  date: new Date(),
  stationaryStoreId: undefined,
};

const InvoiceItem = () => {
  const [invoice, setInvoice] = useState<IInvoice>();
  const [message, setMessage] = useState<string>("");
  const isFormValid = useMemo(
    () => Boolean(invoice && invoice.totalPrice && invoice.stationaryStoreId),
    [invoice]
  );
  const navigate = useNavigate();

  const params = useParams();
  const id = useMemo(
    () => (params["id"] ? parseInt(params["id"]) : undefined),
    [params]
  );

  const getInvoice = useCallback(async () => {
    try {
      if (!Boolean(id)) {
        setInvoice(initialInvoice);
        return;
      }
      const response = await axios.get<IInvoice>("/api/invoiceApi/" + id);
      setInvoice(response.data);
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
          totalPrice: invoice?.totalPrice,
          stationaryStoreId: invoice?.stationaryStoreId,
          date: new Date(),
        };
        id
          ? await axios.put("/api/invoiceApi", request)
          : await axios.post("/api/invoiceApi", request);
        setMessage(id ? "Updated" : "Added");
      } catch {
        setMessage("Error");
      }
    },
    [id, invoice?.stationaryStoreId, invoice?.totalPrice]
  );

  useEffect(() => {
    getInvoice();
  }, [getInvoice]);

  if (!invoice) return <div>loading...</div>;

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
          onClick={() => navigate("/invoice")}
        >
          Back
        </Button>
        <Typography variant="h4">
          {id ? "Edit Invoice" : "Add Invocie"}
        </Typography>
        {id && <Typography variant="body1">ID: {id}</Typography>}
        <TextField
          label="Total price"
          fullWidth
          required
          type="number"
          value={invoice.totalPrice}
          onChange={(e) =>
            setInvoice({ ...invoice, totalPrice: parseInt(e.target.value) })
          }
        />
        <TextField
          label="Store Id"
          fullWidth
          required
          type="number"
          value={invoice.stationaryStoreId}
          onChange={(e) =>
            setInvoice({
              ...invoice,
              stationaryStoreId: parseInt(e.target.value),
            })
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

export default InvoiceItem;
