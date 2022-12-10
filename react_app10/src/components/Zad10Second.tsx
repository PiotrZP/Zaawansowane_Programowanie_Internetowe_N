import React from "react";
import Zad10ISecond from "../model/Zad10ISecond";

const Second = (props: Zad10ISecond) => {
  const { handleButton } = props;
  return (
    <div>
      <span>"Czy chesz dalejqqq uczyć się biblioteki React?</span>
      <div>
        <button onClick={() => handleButton(true)}>TAK</button>
        <button onClick={() => handleButton(false)}>NIE</button>
      </div>
    </div>
  );
};

export default Second;
