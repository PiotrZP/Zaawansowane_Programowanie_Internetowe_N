import "./App.css";

import PhotoGallery from "./components/PhotoGallery/PhotoGallery";


const photos = [
  { src: '../..//assets/File_1.jpg', color: 'red' },
  { src: '../..//assets/File_2.jpg', color: 'green' },
  { src: '../..//assets/File_3.jpg', color: 'blue' },
];

function App() {
  return (
    <div className="App">
       <PhotoGallery photos={photos} />
    </div>
  );
}

export default App;
