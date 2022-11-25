import React, { useState } from "react";
import "./Zad7.css";

const myLinks = [
  "../..//assets/1.jpg",
  "../..//assets/2.jpg",
  "../..//assets/3.jpg",
  "../..//assets/4.jpg",
];

const Zad7 = () => {
  const [value, setValue] = useState<number>(0);

  const nextImage = () => {
    if (value >= myLinks.length - 1) {
      alert("Brak następnych elementów");
    } else {
      setValue(value + 1);
    }
  };

  const previousImage = () => {
    if (value === 0) {
      //sprawdza wartość oraz typ
      alert("Brak następnych elementów");
    } else {
      setValue(value - 1);
    }
  };
  return (
    <div>
      <div>
        <img width={320} height={240} src={myLinks[value]} alt="Pies" />
      </div>
      <div>
        <button onClick={() => previousImage()}>Wstecz</button>
        <button onClick={() => nextImage()}>Przód</button>
      </div>
    </div>
  );
};

export default Zad7;
