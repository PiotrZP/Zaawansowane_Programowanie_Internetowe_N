import React, { useState } from "react";
import { images } from "./images";
import "./Gallery.css";

const Gallery = () => {
  const [counter, setCounter] = useState(0);

  const handleClick = (action: string) => {
    switch (action) {
      case "increment":
        if (counter >= images.length - 1) {
          alert("to ostatnie zdjęcie i nie może być wyświetlone następne");
        } else {
          setCounter((prev) => prev + 1);
        }
        break;
      case "decrement":
        if (counter <= 0) {
          alert("To pierwsze zdjęcie i nie może być wyświetlone wcześniejsze");
        } else {
          setCounter((prev) => prev - 1);
        }
        break;
    }
  };

  return (
    <div className="container">
      <button onClick={() => handleClick("decrement")}>{`<`}</button>
      <img src={images[counter]} alt="brak opisu" width={"400px"} />
      <button onClick={() => handleClick("increment")}>{`>`}</button>
    </div>
  );
};

export default Gallery;
