import "./App.css";
import GalleryComponent from "./components/gallery-component/GalleryComponent";

const images: string[] = [
  "../..//assets/image_1.jpg",
  "../..//assets/image_2.jpg",
  "../..//assets/image_3.jpg",
  "../..//assets/image_4.jpg",
];

function App() {
  return (
    <div className="App">
      <GalleryComponent images={images} />
    </div>
  );
}

export default App;