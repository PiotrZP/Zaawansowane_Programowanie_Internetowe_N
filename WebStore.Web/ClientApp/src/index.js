import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { createRoot } from 'react-dom/client';
import { BrowserRouter, createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';
import { AddressProvider } from './contexts/AddressContext';
import { AddressGrid } from './components/Address/AddressGrid';
import { AddressAdd } from './components/Address/AddressAdd';
import { AddressEdit } from './components/Address/AddressEdit';
import { AddressDelete } from './components/Address/AddressDelete';
import { Root } from './components/Root';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root/>,
    children: [
      {
        index: true,
        path: '/address',
        element: <AddressGrid/>
      },
      {
        path: 'address/add',
        element: <AddressAdd/>
      },
      {
        path: '/address/edit/:id',
        element: <AddressEdit/>
      },
      {
        path: '/address/delete/:id',
        element: <AddressDelete/>
      }
    ]
  },
  
])

ReactDOM.render(
  <RouterProvider router={router} />,
  document.getElementById('root')
)

serviceWorkerRegistration.unregister();
reportWebVitals();
