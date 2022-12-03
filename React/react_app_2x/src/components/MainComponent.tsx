import { useState } from "react";

const MainComponent = (): JSX.Element => {
  const [fullName, setFullName] = useState("");
  return (
    <div>
      <p>{fullName}</p>
      <button onClick={() => setFullName("Antoni Kijjaroentorn")}>button</button>
    </div>
  );
};

export default MainComponent;
