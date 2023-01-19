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
import { IStore } from "../../..//models/IStore";
import DeleteIcon from "@mui/icons-material/Delete";
import Edit from "@mui/icons-material/Edit";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router";
import { SlCell, SlMainContainer } from "./StoreListStyles";

const StoreList = () => {
  const [stores, setStores] = useState<IStore[]>([]);
  const [message, setMessage] = useState<string>("");
  const navigate = useNavigate();

  const getStores = useCallback(async (showMessage?: boolean) => {
    try {
      const response = await axios.get<IStore[]>("/api/storeApi");
      setStores(response.data);
      showMessage && setMessage("Data Updated");
    } catch {
      setMessage("Error");
    }
  }, []);

  const deleteStore = useCallback(
    async (storeId: number) => {
      try {
        await axios.delete("/api/storeApi/" + storeId);
        setMessage("Store deleted");
        await getStores();
      } catch {
        setMessage("Delete error");
      }
    },
    [getStores]
  );

  useEffect(() => {
    getStores(true);
  }, [getStores]);

  const sorted = useMemo(() => stores.sort((a, b) => a.id - b.id), [stores]);

  return (
    <SlMainContainer>
      <Snackbar
        open={Boolean(message)}
        onClose={() => setMessage("")}
        autoHideDuration={4000}
        message={message}
      />
      <Button
        color="primary"
        variant="container"
        onClick={() => navigate("/store/add/")}
      >
        Add
      </Button>
      <TableContainer component={Paper} elevation={12}>
        <Table>
          <TableHead>
            <TableRow sx={{ display: "flex" }}>
              <SlCell>Id</SlCell>
              <SlCell sx={{ width: "100%" }}>Name</SlCell>
              <SlCell>Delete</SlCell>
              <SlCell>Edit</SlCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {sorted.map((store) => (
              <TableRow sx={{ display: "flex" }}>
                <SlCell>{store.id}</SlCell>
                <SlCell sx={{ width: "100%" }}>{store.name}</SlCell>
                <SlCell>
                  <IconButton onClick={() => deleteStore(store.id)}>
                    <DeleteIcon />
                  </IconButton>
                </SlCell>
                <SlCell>
                  <IconButton
                    onClick={() => navigate("/store/edit/" + store.id)}
                  >
                    <Edit />
                  </IconButton>
                </SlCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </SlMainContainer>
  );
};

export default StoreList;
