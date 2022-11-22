import React, { useState } from "react";

const Komunikat = () => {
  return <h1>Komunikat</h1>;
};

const Zad8 = () => {
  const [show, setShow] = useState(false);

  const handleClick = () => {
    setShow((prev) => !prev);
  };

  return (
    <div>
      {show && <Komunikat />}
      <button onClick={handleClick}>Kliknij</button>
    </div>
  );
};

export default Zad8;
