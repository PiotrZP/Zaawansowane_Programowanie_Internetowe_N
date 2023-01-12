import React, { useState } from "react";
import Component2 from "./Component2";
import "./Component1.css"

const Component1 = () => {
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
      {show && <Component2 click={handleDecision} />}
      {decision !== "" && <p>{decision}</p>}
      <button onClick={handleButtonClick}>Button</button>
    </div>
  );
};

export default Component1;