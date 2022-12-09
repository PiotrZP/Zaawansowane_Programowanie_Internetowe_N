import { useState } from "react";


const MainComponent = (): JSX.Element => {
  const [fullName, setFullName] = useState("");
  return (
    <div>
      <p>{fullName}</p>
      <button onClick={() => setFullName("Przemyslaw Chorobski")}>button</button>
    </div>
  );
};

export default MainComponent;