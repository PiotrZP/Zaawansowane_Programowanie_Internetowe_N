import Store from "../models/common/Store";
import { apiClient } from "./apiClient";

const controllerName = "StoreApi/";

export const getStoresRequest = async (): Promise<Store[]> => {
  const response = await apiClient.get(controllerName);
  return response.data;
};
