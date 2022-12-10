import React from "react";
import ISecond from "../model/ISecond";
import "./index.css";

const Second = (props: ISecond) => {
  const { handleButton } = props;
  return (
    <div>
      <span>"Czy chesz dalej uczyć się biblioteki React?</span>
      <div>
        <button id="green" onClick={() => handleButton(true)}>TAK</button>
        <button id="red" onClick={() => handleButton(false)}>NIE</button>
      </div>
    </div>
  );
};

export default Second;
