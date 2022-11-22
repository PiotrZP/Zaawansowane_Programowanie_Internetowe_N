import React, { useState } from "react";
import { zdjecia } from "./zdj/images";

const Zad7 = () => {
  const [counter, setCounter] = useState(0);

  const handleClick = (action: string) => {
    switch (action) {
      case "increment":
        if (counter >= zdjecia.length - 1) {
          alert("To jest ostatnie zdjecie nie mozan wyswietlic nastepnego");
        } else {
          setCounter((prev) => prev + 1);
        }
        break;
      case "decrement":
        if (counter <= 0) {
          alert("To jest pierwsze zdjecie nie mozan wyswietlic poprzedniego");
        } else {
          setCounter((prev) => prev - 1);
        }
        break;
    }
  };

  return (
    <div className="container">
      <button onClick={() => handleClick("decrement")}>{`<`}</button>
      <img src={zdjecia[counter]} alt="brak opisu" width={"400px"} />
      <button onClick={() => handleClick("increment")}>{`>`}</button>
    </div>
  );
};

export default Zad7;
