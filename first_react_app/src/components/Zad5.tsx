import React, { useState, useCallback } from "react";
import "./Zad5.css";

const Zad5 = (): JSX.Element => {
  const [value, setValue] = useState<number>(0);

  const changeValue = useCallback(
    (numer: number) => setValue((value) => value + numer),
    []
  );

  return (
    <div>
      {value}
      <p></p>
      <button onClick={() => changeValue(+1)}>+1</button>
      <button onClick={() => changeValue(-1)}>-1</button>
    </div>
  );
};

export default Zad5;
