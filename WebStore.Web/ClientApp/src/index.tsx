import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import { createRoot } from 'react-dom/client';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';
import { AddressProvider } from './contexts/AddressContext';
import App from './App';
import { StationaryStoreProvider } from './contexts/StationaryStoreContext';
import { InvoiceProvider } from './contexts/InvoiceContext';
import { OrderProvider } from './contexts/OrderContext';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;
const rootElement = document.getElementById('root') as HTMLElement;

const root = createRoot(rootElement);

root.render(
  <BrowserRouter basename={baseUrl}>
    <AddressProvider>
      <StationaryStoreProvider>
        <InvoiceProvider>
          <OrderProvider>
      <App />
      </OrderProvider>
      </InvoiceProvider>
      </StationaryStoreProvider>
    </AddressProvider>
  </BrowserRouter>  
);


serviceWorkerRegistration.unregister();
reportWebVitals();