import { useState } from 'react';
import './App.css';
import ImageGallery from './components/ImageGallery';
import ImagePreview from './components/ImagePreview';

function App() {
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  return (
    <div className="App">
      <div className="App_container">
        <ImageGallery
          changeImageIndex={(index: number) => setCurrentImageIndex(index)}
          currentImageIndex={currentImageIndex}
        />
        <ImagePreview currentImageIndex={currentImageIndex} />
      </div>
    </div>
  );
}

export default App;

