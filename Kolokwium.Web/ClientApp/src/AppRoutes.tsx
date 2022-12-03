import React from "react";
import { AddressGrid } from "./components/address/AddressGrid";

import { MuiTest } from "./components/MuiTest";

const AppRoutes = [
  {
    index: true,
    element: <AddressGrid />,
  },
  {
    path: "/address",
    element: <AddressGrid />,
  },
  {
    path: "/address/add",
    element: <AddressAdd />,
  },
];

export default AppRoutes;
