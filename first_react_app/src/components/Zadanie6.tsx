import { useState } from 'react';

export const Zadanie6 = () => {
  const [counter, setCounter] = useState<number>(0);
  const handleIncrementValue = (type: string, step: number) => {
    if (type === 'increment') setCounter((prevCounter) => prevCounter + step);
    if (type === 'decrement') setCounter((prevCounter) => prevCounter - step);
  };

  return (
    <>
      <button onClick={() => handleIncrementValue('decrement', 2)}>-2</button>
      <button onClick={() => handleIncrementValue('decrement', 1)}>-1</button>
      <p>{counter}</p>
      <button onClick={() => handleIncrementValue('increment', 1)}>+1</button>
      <button onClick={() => handleIncrementValue('increment', 2)}>+2</button>
    </>
  );
};
