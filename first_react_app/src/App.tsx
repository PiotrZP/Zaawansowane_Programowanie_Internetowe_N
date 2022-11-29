import React from 'react';
import logo from './logo.svg';
import './App.css';
import { ProductList } from './components/ProductList';
import IProduct from './models/IProduct';
import { ProductListItem } from './components/ProductListItem';

function App() {
  let staticProducts: Array<IProduct> = [
    {
      id: 1,
      name :"DELL",
      type : "Computers",
      price: 4000
    },
    { 
      id: 2,
      name :"Logitech 2000",
      type : "Mouses",
      price: 30
    }
  ]

  return (
    <div className='App'>
      <ProductList products={staticProducts}></ProductList>
    </div>
  );

//   return (
//     <div className='App'>
//       <ProductListItem id={1} name={"PC"} type={"Computers"} price={4000}></ProductListItem>
//     </div>
//   );
}

export default App;
