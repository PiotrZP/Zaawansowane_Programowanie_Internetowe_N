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
import { IInvoice } from "../../../models/IInvoice";
import { IlCell, IlMainContainer } from "./InvoiceListStyles";

const InvoiceList = () => {
  const [invoices, setInvoices] = useState<IInvoice[]>([]);
  const [message, setMessage] = useState<string>("");
  const navigate = useNavigate();

  const getInvoices = useCallback(async (showMessage?: boolean) => {
    try {
      const response = await axios.get<IInvoice[]>("/api/invoiceApi");
      setInvoices(response.data);
      showMessage && setMessage("Data Updated");
    } catch {
      setMessage("Error");
    }
  }, []);

  const deleteInvoice = useCallback(
    async (invoiceId: number) => {
      try {
        await axios.delete("/api/invoiceApi/" + invoiceId);
        setMessage("Invoice deleted");
        await getInvoices();
      } catch {
        setMessage("Delete error");
      }
    },
    [getInvoices]
  );

  useEffect(() => {
    getInvoices(true);
  }, [getInvoices]);

  const sorted = useMemo(
    () => invoices.sort((a, b) => a.id - b.id),
    [invoices]
  );

  return (
    <IlMainContainer>
      <Snackbar
        open={Boolean(message)}
        onClose={() => setMessage("")}
        autoHideDuration={4000}
        message={message}
      />
      <Button
        color="primary"
        variant="container"
        onClick={() => navigate("/invoice/add/")}
      >
        Add
      </Button>
      <TableContainer component={Paper} elevation={12}>
        <Table>
          <TableHead>
            <TableRow sx={{ display: "flex" }}>
              <IlCell>Id</IlCell>
              <IlCell sx={{ width: "100%" }}>Total price</IlCell>
              <IlCell sx={{ width: "100%" }}>Date</IlCell>
              <IlCell sx={{ width: "100%" }}>Store Id</IlCell>
              <IlCell>Delete</IlCell>
              <IlCell>Edit</IlCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {sorted.map((invoice) => (
              <TableRow sx={{ display: "flex" }}>
                <IlCell>{invoice.id}</IlCell>
                <IlCell sx={{ width: "100%" }}>{invoice.totalPrice}</IlCell>
                <IlCell sx={{ width: "100%" }}>
                  {new Date(invoice.date).toISOString().split("T")[0]}
                </IlCell>
                <IlCell sx={{ width: "100%" }}>
                  {invoice.stationaryStoreId}
                </IlCell>

                <IlCell>
                  <IconButton onClick={() => deleteInvoice(invoice.id)}>
                    <DeleteIcon />
                  </IconButton>
                </IlCell>
                <IlCell>
                  <IconButton
                    onClick={() => navigate("/invoice/edit/" + invoice.id)}
                  >
                    <Edit />
                  </IconButton>
                </IlCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </IlMainContainer>
  );
};

export default InvoiceList;
