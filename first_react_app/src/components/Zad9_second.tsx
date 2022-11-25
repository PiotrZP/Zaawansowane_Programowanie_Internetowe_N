import React from "react";
import Zad9_second_Props from "./Zad9_second_Props";

const Zad9_second = (props: Zad9_second_Props) => {
  return (
    <div>
      <div>Drugi komponent! </div>
      <button onClick={() => props.Hide()}>Hide Component</button>
    </div>
  );
};

export default Zad9_second;
