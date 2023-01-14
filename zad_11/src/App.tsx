import React from 'react';
import logo from './logo.svg';
import './App.css';
import Gallery from './components/gallery';

function App() {
  const images = [
    { id: 1, src: 'https://cdn.pixabay.com/photo/2023/01/02/04/13/dog-7691238_960_720.jpg' },
    { id: 2, src: 'https://cdn.pixabay.com/photo/2023/01/10/16/23/hedgehog-7710053_960_720.jpg' },
    { id: 3, src: 'https://cdn.pixabay.com/photo/2022/12/24/11/27/lai-da-palpuogna-7675735_960_720.jpg' },
    { id: 4, src: 'https://cdn.pixabay.com/photo/2022/08/01/18/35/ocean-7358753_960_720.jpg' },
  ];
  return (
    <div className="App">
      <h1>My Gallery</h1>
      <Gallery images={images} />
    </div>
  );
}

export default App;
