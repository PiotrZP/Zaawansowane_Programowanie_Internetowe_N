import  { useState } from "react";
import SecondComponent from "../second-component/SecondComponent";

const FirstComponent = (): JSX.Element => {
  const [isVisible, setIsVisible] = useState(false);
  const [message, setMessage] = useState("");

  const handleButton = (confirm: boolean) => {
    setIsVisible(false);
    const newMessage = confirm
      ? "Ciesze sie! Idzmy dalej!"
      : "Przykro mi, że się meczysz!";
    setMessage(newMessage);
  };

  return (
    <div>
      <div>
        <button onClick={() => setIsVisible(true)}>Let's see</button>
      </div>
      {isVisible && <SecondComponent handleButton={handleButton} />}
      {!isVisible && message}
    </div>
  );
};

export default FirstComponent;
