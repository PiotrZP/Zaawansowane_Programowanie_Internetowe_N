import React, { FC } from "react";
import "./DrugiKomponent.css"

interface DrugiKomponent {
  click: (text: string) => void;
}

const DrugiKomponent: FC<DrugiKomponent> = ({ click }) => {
  return (
    <div className="pierwszy">
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

export default DrugiKomponent;