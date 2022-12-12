import { useState } from "react";

const ComponentTask2 = () => {
  const [name, setName] = useState("");
  return (
    <div>
      <p>{name}</p>
      <button onClick={() => setName("Adam Dunajewski")}>Autor</button>
    </div>
  );
};

export default ComponentTask2;
