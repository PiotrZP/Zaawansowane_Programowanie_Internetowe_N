import "./App.css";
import GalleryComponent from "./components/GalleryComponent";

const images: string[] = [
  "../..//assets/image1.jpg",
  "../..//assets/image2.jpg",
  "../..//assets/image3.jpg",
  "../..//assets/image4.jpg",
];

function App() {
  return (
    <div className="App">
      <GalleryComponent images={images} />
    </div>
  );
}

export default App;