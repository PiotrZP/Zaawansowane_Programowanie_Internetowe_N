import React from "react";
import { AddressAdd } from "./components/address/AddressAdd";
import { AddressDelete } from "./components/address/AddressDelete";
import { AddressEdit } from "./components/address/AddressEdit";
import { AddressGrid } from "./components/address/AddressGrid";
import HomeGrid from "./components/home/HomeGrid";
import { InvoiceAdd } from "./components/invoice/InvoiceAdd";
import { InvoiceDelete } from "./components/invoice/InvoiceDelete";
import { InvoiceGrid } from "./components/invoice/InvoiceGrid";


import { ProductAdd } from "./components/product/ProductAdd";
import { ProductDelete } from "./components/product/ProductDelete";
import { ProductEdit } from "./components/product/ProductEdit";
import { ProductGrid } from "./components/product/ProductGrid";

const AppRoutes = [
  {
    index: true,
    element: <HomeGrid />,
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
  {
    path: "/invoice",
    element: <InvoiceGrid/>
  },
  {
    path: "/invoice/add",
    element: <InvoiceAdd/>
  },
  {
    path: "/invoice/edit/:id",
    element: <InvoiceAdd/>
  },
  {
    path: "/invoice/delete/:id",
    element: <InvoiceDelete/>
  },
];

export default AppRoutes;
