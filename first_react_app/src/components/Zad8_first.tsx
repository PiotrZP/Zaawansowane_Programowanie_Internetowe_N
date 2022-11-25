import React, { useState } from "react";
import Zad8_second from "./Zad8_second";

const Zad8_first = () => {
  const [value, setValue] = useState<boolean>(false);
  const showComponent = () => {
    if (value === true) {
      setValue(false);
    } else {
      setValue(true);
    }
  };

  return (
    <div>
      <div>Pierwszy komponent!</div>
      <button onClick={() => showComponent()}>Show</button>
      {value && (
        <div>
          <Zad8_second />
        </div>
      )}
    </div>
  );
};

export default Zad8_first;
