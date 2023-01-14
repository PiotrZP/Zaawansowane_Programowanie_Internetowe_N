import { Home } from "./components/Home";
import { AddressGrid } from './components/Address/AddressGrid';
import { AddressAdd } from "./components/Address/AddressAdd";
import { AddressDelete } from "./components/Address/AddressDelete";
import React from "react";
import { AddressEdit } from "./components/Address/AdressEdit";
import { StationaryStoreGrid } from "./components/StationaryStore/StationaryStoreGrid";
import { StationaryStoreAdd } from "./components/StationaryStore/StationaryStoreAdd";
import { StationaryStoreDelete } from "./components/StationaryStore/StationaryStoreDelete";
import { StationaryStoreEdit } from "./components/StationaryStore/StationaryStoreEdit";
import { InvoiceGrid } from "./components/Invoice/InvoiceGrid";
import { InvoiceAdd } from "./components/Invoice/InvoiceAdd";
import { InvoiceAddOrEditForm } from "./components/Invoice/InvoiceAddOrEditForm";
import { InvoiceEdit } from "./components/Invoice/InvoiceEdit";
import { InvoiceDelete } from "./components/Invoice/InvoiceDelete";
import { OrderGrid } from "./components/Order/OrderGrid";
import { OrderAdd } from "./components/Order/OrderAdd";
import { OrderEdit } from "./components/Order/OrderEdit";
import { OrderDelete } from "./components/Order/OrderDelete";

const AppRoutes = [
    {
        index: true,
        element: [<AddressGrid />, <StationaryStoreGrid/>]
    }, 
    {
        path: '/home',
        element: <Home />
    },
    {
        path: '/address',
        element: <AddressGrid />
    },
    {
        path: '/address/add',
        element: <AddressAdd />
    },
    {
        path: '/address/edit/:id',
        element: <AddressEdit />
    },
    {
        path: '/address/delete/:id',
        element: <AddressDelete />
    },
    {
        path: '/StationaryStore',
        element: <StationaryStoreGrid />
    },
    {
        path: '/StationaryStore/add',
        element: <StationaryStoreAdd />
    },
    {
        path: '/StationaryStore/edit/:id',
        element: <StationaryStoreEdit />
    },
    {
        path: '/StationaryStore/delete/:id',
        element: <StationaryStoreDelete />
    }, 
    {
        path: '/Invoice',
        element: <InvoiceGrid />
    },
    {
        path: '/Invoice/add',
        element: <InvoiceAdd />
    },
    {
        path: '/Invoice/edit/:id',
        element: <InvoiceEdit />
    },
    {
        path: '/Invoice/delete/:id',
        element: <InvoiceDelete />
    },
    {
        path: '/Order',
        element: <OrderGrid />
    },
    {
        path: '/Order/add',
        element: <OrderAdd />
    },
    {
        path: '/Order/edit/:id',
        element: <OrderEdit />
    },
    {
        path: '/Order/delete/:id',
        element: <OrderDelete />
    },
];

export default AppRoutes;