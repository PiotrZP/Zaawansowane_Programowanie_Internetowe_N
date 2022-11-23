import { useState } from 'react';

import './MyComponent.css';

function MyComponent() {
  const [counter, setCounter] = useState<number>(0);

  return (
    <div className="my-component">
      <button onClick={() => setCounter(counter - 2)}>-2</button>
      <button onClick={() => setCounter(counter - 1)}>-1</button>
      <p>{counter}</p>
      <button onClick={() => setCounter(counter + 1)}>+1</button>
      <button onClick={() => setCounter(counter + 2)}>+2</button>
    </div>
  );
}

export default MyComponent;

