import { Home } from "./components/Home";
import { AddressGrid } from "./components/address/AddressGrid";
import { AddressAdd } from "./components/address/AddressAdd";
import { AddressEdit } from "./components/address/AddressEdit";
import { AddressDelete } from "./components/address/AddressDelete";
import React from "react";
import StoreList from "./components/store/store-list/StoreList";
import StoreItem from "./components/store/store-item/StoreItem";
import ProductItem from "./components/product/product-item/ProductItem";
import ProductList from "./components/product/product-list/ProductList";
import InvoiceList from "./components/invoice/invoice-list/InvoiceList";
import InvoiceItem from "./components/invoice/invoice-item/InvoiceItem";
import OrderList from "./components/order/order-list/OrderList";
import OrderItem from "./components/order/order-item/OrderItem";
import { Chat } from "./components/chat/Chat";

const AppRoutes = [
  {
    index: true,
    element: <AddressGrid />,
  },
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
    path: "/store/",
    element: <StoreList />,
  },
  {
    path: "/store/edit/:id",
    element: <StoreItem />,
  },
  {
    path: "/store/add",
    element: <StoreItem />,
  },
  {
    path: "/product/",
    element: <ProductList />,
  },
  {
    path: "/product/edit/:id",
    element: <ProductItem />,
  },
  {
    path: "/product/add",
    element: <ProductItem />,
  },
  {
    path: "/invoice/",
    element: <InvoiceList />,
  },
  {
    path: "/invoice/edit/:id",
    element: <InvoiceItem />,
  },
  {
    path: "/invoice/add",
    element: <InvoiceItem />,
  },
  {
    path: "/order/",
    element: <OrderList />,
  },
  {
    path: "/order/edit/:id",
    element: <OrderItem />,
  },
  {
    path: "/order/add",
    element: <OrderItem />,
  },
  {
    path: "/chat",
    requireAuth: true,
    element: <Chat />,
  },
];

export default AppRoutes;
