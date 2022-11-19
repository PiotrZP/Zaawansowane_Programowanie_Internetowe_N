/*
import React from 'react';
//import logo from './logo.svg';
import './App.css';
import { ProductList } from './components/ProductList';
import IProduct from './models/IProduct';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
 
  let staticProducts: Array<IProduct> = [
    {
      id: 1,
      name: "DELL",
      type: "Computers",
      price: 4000
    },
    {
      id: 2,
      name: "Logitech 2000",
      type: "Mouses",
      price: 30
    },
  ]
  return (
    <div className="App">
      <ProductList products={staticProducts}></ProductList>
    </div>
  );


}

export default App;
*/
import React from 'react';
import './App.css';
import { ProductList } from './components/ProductList';
import IProduct from './models/IProduct';
function App() {
  let staticProducts: Array<IProduct> = [
    {
      id: 1,
      name: "DELL",
      type: "Computers",
      price: 4000
    },
    {
      id: 2,
      name: "Logitech 2000",
      type: "Mouses",
      price: 30
    },
  ]
  return (
    <div className="App">
      <ProductList products={staticProducts}></ProductList>
    </div>
  );
}
export default App;