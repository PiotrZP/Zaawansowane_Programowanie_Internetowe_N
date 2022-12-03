import React from "react";
import { useState } from "react";
import Second from "./Second";

const First = () => {
  const [isVisible, setIsVisible] = useState(false);

  return (
    <div>
      <button onClick={() => setIsVisible(!isVisible)}>Toggle</button>
      {isVisible && <Second toggleComponent={setIsVisible} />}
    </div>
  );
};

export default First;