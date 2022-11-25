import React, { useState } from "react";
import Zad10_second from "./Zad10_second";

const Zad10_first = () => {
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
          <Zad10_second Hide={() => showComponent()} />
        </div>
      )}
    </div>
  );
};

export default Zad10_first;
