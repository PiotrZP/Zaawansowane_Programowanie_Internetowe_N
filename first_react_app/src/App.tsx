import React from "react";
import "./App.css";
import AddProductToList from "./components/AddProductToList";
import ProductList from "./components/ProductList";
import IProduct from "./models/IProduct";

import Zad2 from "./zadania/Zad2";
import Zad3 from "./zadania/Zad3";
import Zad4 from "./zadania/Zad4";
import Zad5 from "./zadania/Zad5";
import Zad6 from "./zadania/Zad6";

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
      {/* <Zad2 /> */}
      {/* <Zad3 /> */}
      {/* <Zad4 /> */}
      {/* <Zad5 /> */}
      <Zad6 />
    </div>
  );
}
export default App;
