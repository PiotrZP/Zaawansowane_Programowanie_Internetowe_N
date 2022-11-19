import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { ProductListItem } from "./components/ProductListItem";
import { ProductList } from "./components/ProductList";

export interface IProduct {
  id: number;
  name: string;
  price: number;
  type: string;
}

function App() {
  const staticProducts: Array<IProduct> = [
    {
      id: 1,
      name: "DELL",
      type: "Computers",
      price: 4000,
    },
    {
      id: 2,
      name: "Logitech 2000",
      type: "Mouses",
      price: 30,
    },
  ];

  return (
    <div className="App">
      <ProductList products={staticProducts} />
    </div>
  );
}

export default App;
