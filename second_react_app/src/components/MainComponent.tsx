import { useState } from "react";

const MainComponent = (): JSX.Element => {
  const [fullName, setFullNameOnClick] = useState("");
  return (
    <div>
      <p>{fullName}</p>
      <button onClick={() => setFullNameOnClick("Michał Zymek")}>button</button>
    </div>
  );
};

export default MainComponent;