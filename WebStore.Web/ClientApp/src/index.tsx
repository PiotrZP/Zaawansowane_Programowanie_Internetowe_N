import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";
import { AddressProvider } from "./contexts/AddressContext";
import { InvoiceProvider } from "./contexts/InvoiceContext";
import { StoreProvider } from "./contexts/StoreContext";
import { OrderProvider } from "./contexts/OrderContext";
import { ProductProvider } from "./contexts/ProductContext";
const baseUrl = document
  .getElementsByTagName("base")[0]
  .getAttribute("href") as string;
const rootElement = document.getElementById("root") as HTMLElement;
const root = createRoot(rootElement);
root.render(
  <BrowserRouter basename={baseUrl}>
    <InvoiceProvider>
      <AddressProvider>
        <StoreProvider>
          <OrderProvider>
            <ProductProvider>
              <App />
            </ProductProvider>
          </OrderProvider>
        </StoreProvider>
      </AddressProvider>
    </InvoiceProvider>
  </BrowserRouter>
);
serviceWorkerRegistration.unregister();
reportWebVitals();
