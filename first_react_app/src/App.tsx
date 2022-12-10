import './App.css';
import { ProductList } from './components/ProductList';
import { Zadanie10 } from './components/Zadanie10/Zadanie10';
import { Zadanie11 } from './components/Zadanie11';
import { Zadanie2 } from './components/Zadanie2';
import { Zadanie3 } from './components/Zadanie3';
import { Zadanie4 } from './components/Zadanie4';
import { Zadanie5 } from './components/Zadanie5';
import { Zadanie6 } from './components/Zadanie6';
import { Zadanie7 } from './components/Zadanie7';
import { Zadanie8 } from './components/Zadanie8/Zadanie8';
import { Zadanie9 } from './components/Zadanie9/Zadanie9';
import 'bootstrap/dist/css/bootstrap.min.css';

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
      name: 'DELL',
      type: 'Computers',
      price: 4000,
    },
    {
      id: 2,
      name: 'Logitech 2000',
      type: 'Mouses',
      price: 30,
    },
  ];

  return (
    <div className="App">
      <ProductList products={staticProducts} />
      <Zadanie2 />
      <Zadanie3 />
      <Zadanie4 />
      <Zadanie5 />
      <Zadanie6 />
      <Zadanie7 />
      <Zadanie8 />
      <Zadanie9 />
      <Zadanie10 />
      <Zadanie11 />
    </div>
  );
}

export default App;
