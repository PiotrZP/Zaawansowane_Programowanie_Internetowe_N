import React, { useState } from "react";
import DrugiKomponent from "./DrugiKomponent";
import "./Button.css"

const Button = () => {
    const [decision, setDecision] = useState("");
    const [show, setShow] = useState(false);
  
    const handleDecision = (text: string) => {
      setDecision((prev) => (prev = text));
      handleButtonClick();
    };
    const handleButtonClick = () => {
      setShow((prev) => !prev);
      if (decision !== "") {
        setDecision((prev) => (prev = ""));
      }
    };
  
    return (
      <div className="container">
        {show && <DrugiKomponent click={handleDecision} />}
        {decision !== "" && <h1>{decision}</h1>}
        <button className="click" onClick={handleButtonClick}>Kliknij</button>
      </div>
    );
  };
  
  export default Button;