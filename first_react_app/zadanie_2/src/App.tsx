import React from 'react';
import './App.css';
import { ProductList } from './components/ProductList';
import IProduct from './models/dane';
function App() {
  let staticProducts: Array<IProduct> = [
    {
      name: "Przemysław",
      last_name: "Choróbski",
    },

  ]
  return (
    <div className="App">
      <ProductList products={staticProducts}></ProductList>
    </div>
  );
}
export default App;
