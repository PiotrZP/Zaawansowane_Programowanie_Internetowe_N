import Product from "../models/common/Product";
import { apiClient } from "./apiClient";

const controllerName = "productApi/";

export const getProductsRequest = async (): Promise<Product[]> => {
  const response = await apiClient.get(controllerName);
  return response.data;
};
