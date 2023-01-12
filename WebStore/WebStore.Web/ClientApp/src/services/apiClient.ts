import axios from "axios";

const baseApiUrl = "https://localhost:7119/api/";

export const apiClient = axios.create({ baseURL: baseApiUrl });
