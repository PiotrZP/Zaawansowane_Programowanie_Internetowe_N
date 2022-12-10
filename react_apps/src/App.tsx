import "./App.css";
import IProductProps from "./model/IProductProps";
import ProductList from "./components/zad1/ProductList";

const staticProducts: IProductProps[] = [
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

function App() {
  return (
    <div className="main-container">
      <div className="App">
        <ProductList products={staticProducts} />
      </div>
      


    </div>
  );
}

export default App;
