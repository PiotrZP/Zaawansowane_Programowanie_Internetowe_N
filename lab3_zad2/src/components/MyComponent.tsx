import { useState } from 'react';
import './MyComponent.css';

const imageList = [
  'https://images.pexels.com/photos/1001682/pexels-photo-1001682.jpeg',
  'https://images.pexels.com/photos/3408744/pexels-photo-3408744.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/2662116/pexels-photo-2662116.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/2559941/pexels-photo-2559941.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/290595/pexels-photo-290595.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
];

function MyComponent() {
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  const nextImage = () => {
    if(currentImageIndex == imageList.length - 1) {
      return alert("To ostatnie zdjęcie!");
    }

    setCurrentImageIndex(currentImageIndex + 1);
  };

  const prevImage = () => {
    if(currentImageIndex == 0) {
      return alert('To pierwsze zdjęcie!');
    }
    setCurrentImageIndex(currentImageIndex - 1);
  };

  return (
    <div className="my-component">
      <div className="controls">
        <button onClick={prevImage}>Poprzednie</button>
        <button onClick={nextImage}>Następne</button>
      </div>
      
      <img src={imageList[currentImageIndex]} alt="image gallery" />

    </div>
  );
}

export default MyComponent;


