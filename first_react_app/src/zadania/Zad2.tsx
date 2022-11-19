import React, { useState } from "react";

const Zad2 = () => {
  const [show, setShow] = useState(false);

  const handleShowName = () => {
    setShow((prev) => !prev);
  };

  return (
    <div>
      <p>{show === true ? "Michał Szuleta" : null}</p>
      <button onClick={handleShowName}>pokaż</button>
    </div>
  );
};

export default Zad2;
