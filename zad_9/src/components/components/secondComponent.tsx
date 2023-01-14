import { useState } from "react";
import FirstComponent from "./firstComponent";

const SecondComponent: React.FC = () => {
  const [showFirst, setShowFirst] = useState(false);

  return (
    <div>
      <button onClick={() => setShowFirst(true)}>
        Pokaż pierwszy komponent
      </button>
      {showFirst && <FirstComponent onClose={() => setShowFirst(false)} />}
    </div>
  );
};
  export default SecondComponent