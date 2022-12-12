import "./App.css";
import IProductProps from "./model/IProductProps";
import ProductList from "./components/zad1/ProductList";
import ComponentTask2 from "./components/zad2/ComponentTask2";
import ComponentTask3and4 from "./components/zad3/ComponentTask3and4";
import ComponentTask5and6 from "./components/zad5/ComponentTask5and6";
import ComponentTask7 from "./components/zad7/ComponentTask7";
import First from "./components/zad8/First";
import Prime from "./components/zad10/Prime";
import Gallery from "./components/zad11/Gallery";

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

const imgs: string[] = [
  "..//img/im0.jpg",
  "..//img/im1.jpg",
  "..//img/im2.jpg",
  "..//img/im3.jpg",
  "..//img/im4.jpg",
];

function App() {
  return (
    <div className="main-container">
      <div className="App">
        <ProductList products={staticProducts} />
      </div>
      <div>
        <ComponentTask2 />
      </div>
      <div>
        <ComponentTask3and4 />
      </div>
      <div>
        <ComponentTask5and6 />
      </div>
      <div>
        <ComponentTask7 images={imgs} />
      </div>
      <div>
        <First />
      </div>
      <div>
        <Prime />
      </div>
      <div>
        <Gallery images={imgs} />
      </div>
    </div>
  );
}

export default App;
