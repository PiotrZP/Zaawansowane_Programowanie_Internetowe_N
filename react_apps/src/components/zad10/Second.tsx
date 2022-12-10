import React from "react";
import ISecondProps from "../../model/ISecondProps";

const Second = (props: ISecondProps) => {
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
