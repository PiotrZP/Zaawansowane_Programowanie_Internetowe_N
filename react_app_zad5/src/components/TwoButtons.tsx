import React, { useState } from "react";

const TwoButtons = () => {
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
      <p>{number}</p>
      <button
        onClick={() => {
          handleClick(1);
        }}
      >
        +1
      </button>
    </>
  );
};

export default TwoButtons;