import { useState } from 'react';

export const Zadanie5 = () => {
  const [counter, setCounter] = useState<number>(0);

  return (
    <>
      <button onClick={() => setCounter((prevCounter) => --prevCounter)}>
        -1
      </button>
      <p>{counter}</p>
      <button onClick={() => setCounter((prevCounter) => ++prevCounter)}>
        +1
      </button>
    </>
  );
};
