import "./App.css";
import MainComponent from "./components/MainComponent";

const images: string[] = [
  "../..//assets/File_1.jpg",
  "../..//assets/File_2.jpg",
  "../..//assets/File_3.jpg",
  "../..//assets/File_4.jpg",
];

function App() {
  return (
    <div className="App">
      <MainComponent images={images} />
    </div>
  );
}

export default App;
