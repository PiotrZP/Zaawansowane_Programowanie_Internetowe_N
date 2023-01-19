import { Snackbar, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import axios from "axios";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "reactstrap";
import { IStore } from "../../../models/IStore";

const initialStore: IStore = {
  id: 0,
  name: "",
};

const StoreItem = () => {
  const [store, setStore] = useState<IStore>();
  const [message, setMessage] = useState<string>("");
  const isFormValid = useMemo(() => Boolean(store && store.name), [store]);
  const navigate = useNavigate();

  const params = useParams();
  const id = useMemo(
    () => (params["id"] ? parseInt(params["id"]) : undefined),
    [params]
  );

  const getStore = useCallback(async () => {
    try {
      if (!Boolean(id)) {
        setStore(initialStore);
        return;
      }
      const response = await axios.get<IStore>("/api/storeApi/" + id);
      setStore(response.data);
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
          name: store?.name,
        };
        id
          ? await axios.put("/api/storeApi", request)
          : await axios.post("/api/storeApi", request);
        setMessage(id ? "Updated" : "Added");
      } catch {
        setMessage("Error");
      }
    },
    [id, store?.name]
  );

  useEffect(() => {
    getStore();
  }, [getStore]);

  if (!store) return <div>loading...</div>;

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
          onClick={() => navigate("/store")}
        >
          Back
        </Button>
        <Typography variant="h4">{id ? "Edit Store" : "Add Store"}</Typography>
        {id && <Typography variant="body1">ID: {id}</Typography>}
        <TextField
          label="Name"
          fullWidth
          required
          value={store.name}
          onChange={(e) => setStore({ ...store, name: e.target.value })}
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
