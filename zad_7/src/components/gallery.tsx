import React, { useState } from 'react';

interface Image {
  url: string;
}

const images: Image[] = [
  { url: 'https://cdn.pixabay.com/photo/2023/01/02/04/13/dog-7691238_960_720.jpg' },
  { url: 'https://cdn.pixabay.com/photo/2022/10/25/11/01/apples-7545504_960_720.jpg' },
  { url: 'https://cdn.pixabay.com/photo/2022/09/24/07/32/flowers-7475758_960_720.png' },
];

const Gallery: React.FC = () => {
  const [currentImage, setCurrentImage] = useState(0);
  const [alert, setAlert] = useState('');

  const handlePrevious = () => {
    if (currentImage === 0) {
      setAlert('This is the first image');
    } else {
      setCurrentImage(currentImage - 1);
      setAlert('');
    }
  };

  const handleNext = () => {
    if (currentImage === images.length - 1) {
      setAlert('This is the last image');
    } else {
      setCurrentImage(currentImage + 1);
      setAlert('');
    }
  };

  return (
    <div>
      <img src={images[currentImage].url} alt="current" />
      <button onClick={handlePrevious}>Previous</button>
      <button onClick={handleNext}>Next</button>
      {alert && <p>{alert}</p>}
    </div>
  );
};

export default Gallery;