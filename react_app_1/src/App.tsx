import "./App.css";
import ProductList from "./components/product-list/ProductList";
import IProduct from "./models/IProduct";

const staticProducts: IProduct[] = [
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
    <div className="App">
      <ProductList products={staticProducts} />
    </div>
  );
}

export default App;
