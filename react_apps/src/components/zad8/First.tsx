import { useState } from "react";
import Next from "./Next";

const First = () => {
  const [isVisible, setIsVisible] = useState(false);

  return (
    <div>
      <button onClick={() => setIsVisible(!isVisible)}>Toggle</button>
      {isVisible && <Next toggleComponent={setIsVisible} />}
    </div>
  );
};

export default First;
