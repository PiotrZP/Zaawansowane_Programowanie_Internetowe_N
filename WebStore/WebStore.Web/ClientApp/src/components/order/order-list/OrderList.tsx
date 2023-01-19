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
import { OlCell, OlMainContainer } from "./OrderListStyles";
import { IOrder } from "../../../models/IOrder";

const OrderList = () => {
  const [orders, setOrders] = useState<IOrder[]>([]);
  const [message, setMessage] = useState<string>("");
  const navigate = useNavigate();

  const getOrders = useCallback(async (showMessage?: boolean) => {
    try {
      const response = await axios.get<IOrder[]>("/api/orderApi");
      setOrders(response.data);
      showMessage && setMessage("Data Updated");
    } catch {
      setMessage("Error");
    }
  }, []);

  const deleteOrder = useCallback(
    async (orderId: number) => {
      try {
        await axios.delete("/api/orderApi/" + orderId);
        setMessage("Order deleted");
        await getOrders();
      } catch {
        setMessage("Delete error");
      }
    },
    [getOrders]
  );

  useEffect(() => {
    getOrders(true);
  }, [getOrders]);

  const sorted = useMemo(() => orders.sort((a, b) => a.id - b.id), [orders]);

  return (
    <OlMainContainer>
      <Snackbar
        open={Boolean(message)}
        onClose={() => setMessage("")}
        autoHideDuration={4000}
        message={message}
      />
      <Button
        color="primary"
        variant="container"
        onClick={() => navigate("/order/add/")}
      >
        Add
      </Button>
      <TableContainer component={Paper} elevation={12}>
        <Table>
          <TableHead>
            <TableRow sx={{ display: "flex" }}>
              <OlCell>Id</OlCell>
              <OlCell>Total amount</OlCell>
              <OlCell sx={{ width: "100%" }}>Tracking number</OlCell>
              <OlCell sx={{ width: "100%" }}>Delivery date</OlCell>
              <OlCell sx={{ width: "100%" }}>Order date</OlCell>
              <OlCell>Store Id</OlCell>
              <OlCell>Invoice Id</OlCell>
              <OlCell>Delete</OlCell>
              <OlCell>Edit</OlCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {sorted.map((order) => (
              <TableRow sx={{ display: "flex" }}>
                <OlCell>{order.id}</OlCell>
                <OlCell>{order.totalAmount}</OlCell>
                <OlCell sx={{ width: "100%" }}>{order.trackingNumber}</OlCell>
                <OlCell sx={{ width: "100%" }}>
                  {new Date(order.deliveryDate).toISOString().split("T")[0]}
                </OlCell>
                <OlCell sx={{ width: "100%" }}>
                  {new Date(order.orderDate).toISOString().split("T")[0]}
                </OlCell>
                <OlCell>{order.stationaryStoreId}</OlCell>
                <OlCell>{order.invoiceid}</OlCell>
                <OlCell>
                  <IconButton onClick={() => deleteOrder(order.id)}>
                    <DeleteIcon />
                  </IconButton>
                </OlCell>
                <OlCell>
                  <IconButton
                    onClick={() => navigate("/order/edit/" + order.id)}
                  >
                    <Edit />
                  </IconButton>
                </OlCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </OlMainContainer>
  );
};

export default OrderList;
