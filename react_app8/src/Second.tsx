import React from "react";
import { ISecond } from "./model/ISecond";


const Second = (props: ISecond) => {
  const { handleButton } = props;
  return (
    <div>
      <span>"Czy chesz dalej uczyć się biblioteki React?</span>
      <div>
        <button onClick={() => handleButton(true)}>TAK</button>
        <button onClick={() => handleButton(false)}>NIE</button>
      </div>
    </div>
  );
};

export default Second;
