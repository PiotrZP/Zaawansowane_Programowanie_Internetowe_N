import { useState } from "react";
import Second from "./Second";

const Prime = () => {
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
      {isVisible && <Second handleButton={handleButton} />}
      {!isVisible && message}
    </div>
  );
};

export default Prime;
