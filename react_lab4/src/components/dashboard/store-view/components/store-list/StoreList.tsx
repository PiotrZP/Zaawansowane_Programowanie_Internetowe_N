import React, { useCallback, useEffect, useState } from "react";
import { getStoresRequest } from "../../../../../api/StoreController";
import Store from "../../../../../models/common/Store";

const StoreList = () => {
  const [stores, setStores] = useState<Store[]>([]);

  const getStores = useCallback(async () => {
    try {
      const response = await getStoresRequest();
      setStores(response);
    } catch (ex) {
      console.log(ex);
    }
  }, []);

  useEffect(() => {
    getStores();
  }, [getStores]);

  return (
    <div>
      {stores.map((store) => (
        <div key={store.id}>{store.name}</div>
      ))}
    </div>
  );
};

export default StoreList;
