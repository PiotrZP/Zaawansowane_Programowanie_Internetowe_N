import React, { useState } from "react";
import Zad9_second from "./Zad9_second";

const Zad9_first = () => {
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
          <Zad9_second Hide={() => showComponent()} />
        </div>
      )}
    </div>
  );
};

export default Zad9_first;
