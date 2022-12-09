import { useState } from "react";

const Component = (): JSX.Element => {
  const [name, setName] = useState("");
  return (
    <div>
      <p>{name}</p>
      <button onClick={() => setName("Adam Dunajewsi")}>button</button>
    </div>
  );
};

export default Component;
