import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";
import { AddressProvider } from "./contexts/AddressContext";
import { ProductProvider } from "./contexts/ProductContext";
import { InvoiceProvider } from "./contexts/InvoiceContext";
import { CategoryProvider } from "./contexts/CategoryContext";

const baseUrl = document
  .getElementsByTagName("base")[0]
  .getAttribute("href") as string;
const rootElement = document.getElementById("root") as HTMLElement;
const root = createRoot(rootElement);

root.render(
  <BrowserRouter basename={baseUrl}>
    <CategoryProvider>
    <InvoiceProvider>
    <ProductProvider>
      <AddressProvider>
        <App />
      </AddressProvider>
    </ProductProvider>
    </InvoiceProvider>
    </CategoryProvider>
  </BrowserRouter>
);
// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
