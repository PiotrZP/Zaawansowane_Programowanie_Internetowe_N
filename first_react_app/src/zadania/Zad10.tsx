import React, { FC, useState } from "react";

interface DrugiKomponentProps {
  click: (text: string) => void;
}

const DrugiKomponent: FC<DrugiKomponentProps> = ({ click }) => {
  return (
    <div className="drugi">
      <h1 className="drugi-text">
        "Czy chesz dalej uczyć się biblioteki React?
      </h1>
      <button
        className="drugi-btn"
        onClick={() => click("Cieszę się! Idźmy dalej")}
      >
        Tak
      </button>
      <button
        className="drugi-btn"
        onClick={() => click("Przykro mi, że się męczysz!")}
      >
        Nie
      </button>
    </div>
  );
};

const Zad10 = () => {
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
      <button onClick={handleButtonClick}>Kliknij</button>
    </div>
  );
};

export default Zad10;
