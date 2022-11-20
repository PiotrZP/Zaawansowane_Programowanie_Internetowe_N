import { useState } from "react";
import SecondComponent from "../second-component/SecondComponent";

const FirstComponent = (): JSX.Element => {
  const [isVisible, setIsVisible] = useState(false);

  return (
    <div>
      <button onClick={() => setIsVisible(!isVisible)}>Toggle</button>
      {isVisible && <SecondComponent toggleComponent={setIsVisible} />}
    </div>
  );
};

export default FirstComponent;
