import React, { useState } from "react";

const FourButtons = () => {
  const [number, setNumber] = useState(0);

  const handleClick = (value: number) => {
    setNumber((prev) => (prev += value));
  };

  return (
    <>
      <button
        onClick={() => {
          handleClick(-1);
        }}
      >
        -1
      </button>
      <button
        onClick={() => {
          handleClick(-2);
        }}
      >
        -2
      </button>
      <p>{number}</p>
      <button
        onClick={() => {
          handleClick(1);
        }}
      >
        +1
      </button>
      <button
        onClick={() => {
          handleClick(2);
        }}
      >
        +2
      </button>
    </>
  );
};

export default FourButtons;