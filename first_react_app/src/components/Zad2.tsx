import React, { useState } from "react";

const Zad2 = (): JSX.Element => {
  const [myName, setMyName] = useState<string>();

  return (
    <div>
      {myName}
      <button onClick={() => setMyName("Grzegorz Korzus")}>Click</button>
    </div>
  );
};

export default Zad2;
