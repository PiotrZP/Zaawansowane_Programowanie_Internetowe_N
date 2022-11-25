import React from "react";
import Zad10_second_Props from "./Zad10_second_Props";

const Zad10_second = (props: Zad10_second_Props) => {
  return (
    <div>
      <div>Drugi komponent! </div>
      <button onClick={() => props.Hide()}>Hide Component</button>
    </div>
  );
};

export default Zad10_second;
