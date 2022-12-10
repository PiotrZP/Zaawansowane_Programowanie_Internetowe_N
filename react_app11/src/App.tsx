import "./App.css";
import Gallery from "./components/Gallery";

const images: string[] = [
  "..//img/im0.jpg",
  "..//img/im1.jpg",
  "..//img/im2.jpg",
  "..//img/im3.jpg",
  "..//img/im4.jpg",
];
function App() {
  return (
    <div className="App">
      <Gallery images={images} />
    </div>
  );
}

export default App;
