import { Home } from "./components/Home";
import { AddressGrid } from "./components/Address/AddressGrid";
import { AddressAdd } from "./components/Address/AddressAdd";
import { AddressEdit } from "./components/Address/AddressEdit";
import { AddressDelete } from "./components/Address/AddressDelete";
import React from "react";
import { InvoiceGrid } from "./components/Invoice/InvoiceGrid";
import { InvoiceEdit } from "./components/Invoice/InvoiceEdit";
import { InvoiceDelete } from "./components/Invoice/InvoiceDelete";
import { InvoiceAdd } from "./components/Invoice/InvoiceAdd";
import { StoreEdit } from "./components/Store/StoreEdit";
import { StoreAdd } from "./components/Store/StoreAdd";
import { StoreGrid } from "./components/Store/StoreGrid";
import { StoreDelete } from "./components/Store/StoreDelete";
import { OrderGrid } from "./components/Order/OrderGrid";
import { OrderDelete } from "./components/Order/OrderDelete";
import { OrderEdit } from "./components/Order/OrderEdit";
import { OrderAdd } from "./components/Order/OrderAdd";
import { ProductGrid } from "./components/Product/ProductGrid";
import { ProductAdd } from "./components/Product/ProductAdd";
import { ProductDelete } from "./components/Product/ProductDelete";
import { ProductEdit } from "./components/Product/ProductEdit";
const AppRoutes = [
  {
    index: true,
    element: <AddressGrid />,
  },
  // {
  //   index: true,
  //   element: <InvoiceGrid />,
  // },
  {
    path: "/home",
    element: <Home />,
  },
  {
    path: "/address",
    element: <AddressGrid />,
  },
  {
    path: "/address/add",
    element: <AddressAdd />,
  },
  {
    path: "/address/edit/:id",
    element: <AddressEdit />,
  },
  {
    path: "/address/delete/:id",
    element: <AddressDelete />,
  },
  {
    path: "/invoice",
    element: <InvoiceGrid />,
  },
  {
    path: "/invoice/add",
    element: <InvoiceAdd />,
  },
  {
    path: "/invoice/edit/:id",
    element: <InvoiceEdit />,
  },
  {
    path: "/invoice/delete/:id",
    element: <InvoiceDelete />,
  },
  {
    path: "/store",
    element: <StoreGrid />,
  },
  {
    path: "/store/add",
    element: <StoreAdd />,
  },
  {
    path: "/store/edit/:id",
    element: <StoreEdit />,
  },
  {
    path: "/store/delete/:id",
    element: <StoreDelete />,
  },
  {
    path: "/order",
    element: <OrderGrid />,
  },
  {
    path: "/order/add",
    element: <OrderAdd />,
  },
  {
    path: "/order/edit/:id",
    element: <OrderEdit />,
  },
  {
    path: "/order/delete/:id",
    element: <OrderDelete />,
  },
  {
    path: "/product",
    element: <ProductGrid />,
  },
  {
    path: "/product/add",
    element: <ProductAdd />,
  },
  {
    path: "/product/edit/:id",
    element: <ProductEdit />,
  },
  {
    path: "/product/delete/:id",
    element: <ProductDelete />,
  },
];
export default AppRoutes;
