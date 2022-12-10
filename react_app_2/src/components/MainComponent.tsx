import { useState } from "react";

const MainComponent = (): JSX.Element => {
  const [fullName, setFullName] = useState("");
  return (
    <div>
      <p>{fullName}</p>
      <button onClick={() => setFullName("Hubert Rozumek")}>button</button>
    </div>
  );
};

export default MainComponent;
