import React, { useState } from 'react';

interface CounterProps {
  initialValue: number;
}

const Counter: React.FC<CounterProps> = ({ initialValue }) => {
  const [counter, setCounter] = useState(initialValue);

  return (
    <div>
      <p>{counter}</p>
      <button onClick={() => setCounter(counter + 2)}>+2</button>
      <button onClick={() => setCounter(counter + 1)}>+1</button>
      <button onClick={() => setCounter(counter - 1)}>-1</button>
      <button onClick={() => setCounter(counter - 2)}>-2</button>

    </div>
  );
};

export default Counter;