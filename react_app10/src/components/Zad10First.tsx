import React, { useState } from "react";
import Zad10Second from "./Zad10Second";

const Zad10First = () => {
  const [isVisible, setIsVisible] = useState(false);
  const [message, setMessage] = useState("");

  const handleButton = (confirm: boolean) => {
    setIsVisible(false);
    const newMessage = confirm
      ? "Cieszę się! Idźmy dalej!"
      : "Przykro mi, że się męczysz!";
    setMessage(newMessage);
  };

  return (
    <div>
      <div>
        <button onClick={() => setIsVisible(true)}>Pokaż</button>
      </div>
      {isVisible && <Zad10Second handleButton={handleButton} />}
      {!isVisible && message}
    </div>
  );
};

export default Zad10First;
