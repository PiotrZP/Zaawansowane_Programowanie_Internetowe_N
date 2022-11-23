import React, { useState } from "react";
import Komunikat from "./Komunikat";
import "./Przycisk.css"

const Przycisk = () => {
    const [show, setShow] = useState(false);
  
    const handleClick = () => {
      setShow((prev) => !prev);
    };
  
    return (
      <div>
        {show && <Komunikat />}
        <button onClick={handleClick}>Kliknij</button>
      </div>
    );
  };
  
  export default Przycisk;