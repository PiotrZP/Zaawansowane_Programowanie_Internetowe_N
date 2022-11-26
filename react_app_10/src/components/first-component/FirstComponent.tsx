import React, { useState } from "react";
import SecondComponent from "../second-component/SecondComponent";

const FirstComponent = (): JSX.Element => {
  const [isVisible, setIsVisible] = useState(false);
  const [message, setMessage] = useState("");

  const handleButton = (confirm: boolean) => {
    setIsVisible(false);
    const newMessage = confirm
      ? "Cieszę się! Idźmy dalej!"
      : "Przykro mi, że się męczysz!";
    setMessage(newMessage);
  };

  return (
    <div>
      <div>
        <button onClick={() => setIsVisible(true)}>SHOW</button>
      </div>
      {isVisible && <SecondComponent handleButton={handleButton} />}
      {!isVisible && message}
    </div>
  );
};

export default FirstComponent;