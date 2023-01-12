import React, { useState } from "react";
import { photos } from "./Photos";
import "./Slider.css";

const Slider = () => {
    const [counter, setCounter] = useState(0);

    const handleClick = (action: string) => {
        switch (action) {
            case "increment":
                if (counter >= photos.length - 1) {
                    alert("Brak następnych zdjęć");
                } else {
                    setCounter((prev) => prev + 1);
                }
                break;
            case "decrement":
                if (counter <= 0) {
                    alert("Brak wcześniejszych zdjęć");
                } else {
                    setCounter((prev) => prev - 1);
                }
                break;
        }
    };
    
    return (
        <div className="container">
            <button onClick={() => handleClick("decrement")}>{`Prev`}</button>
            <img src={photos[counter]} alt="brak opisu" width={"256px"}/>
            <button onClick={() => handleClick("increment")}>{`Next`}</button>
        </div>
    );
};

export default Slider;