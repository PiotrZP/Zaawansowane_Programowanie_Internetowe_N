import React, { FC } from "react";
import "./Component2.css"

interface Component2 {
  click: (text: string) => void;
}

const Component2: FC<Component2> = ({ click }) => {
  return (
    <div className="pierwszy">
      <p>
        Czy chesz dalej uczyć się biblioteki React?
      </p>
      <button onClick={() => click("Cieszę się! Idźmy dalej")}>
        Tak
      </button>
      <button onClick={() => click("Przykro mi, że się męczysz!")}>
        Nie
      </button>
    </div>
  );
};

export default Component2;