import "./App.css";
import GalleryComponent from "./components/GalleryComponent";

const images: string[] = [
  "../..//assets/File_1.jpg",
  "../..//assets/File_2.jpg",
  "../..//assets/File_3.jpg",
  "../..//assets/File_4.jpg",
];

function App() {
  return (
    <div className="App">
      <GalleryComponent images={images} />
    </div>
  );
}

export default App;
