import React from "react";
import "./App.css";
import { ProductList } from "./components/ProductList";
import Zad2 from "./components/Zad2";
import Zad3 from "./components/Zad3";
import Zad4 from "./components/Zad4";
import Zad5 from "./components/Zad5";

import IProduct from "./models/IProduct";
function App() {
  let staticProducts: Array<IProduct> = [
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
      {/* <ProductList products={staticProducts}></ProductList> */}
      <Zad5 />
    </div>
  );
}
export default App;
