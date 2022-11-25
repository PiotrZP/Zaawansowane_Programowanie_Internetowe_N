import React from "react";
import Zad10_second_Props from "./Zad10_second_Props";

const Zad10_second = (props: Zad10_second_Props) => {
  const Text = (value: boolean) => {
    if (value === true) {
      alert("Cieszymy się! Idź dalej!");
    } else {
      alert("Przykro mi, że się męczysz!");
    }
    props.Hide();
  };
  return (
    <div>
      <div>Czy chcesz dalej uczyć się biblioteki React </div>
      <button onClick={() => Text(true)}>Tak</button>
      <button onClick={() => Text(false)}>Nie</button>
    </div>
  );
};

export default Zad10_second;
