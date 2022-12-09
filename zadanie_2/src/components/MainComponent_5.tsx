import { useCallback, useState } from "react";

const MainComponent = (): JSX.Element => {
  const [value, setValue ] = useState<number>(0);
  const changeValue = (numer: number) => {
    setValue((value) => value + numer)
  }
  return (
    <div>
      <p>{value}</p>
      <button onClick={() => changeValue(-2)}>-2</button>
      <button onClick={() => changeValue(-1)}>-1</button>
      <button onClick={() => changeValue(+1)}>+1</button>
      <button onClick={() => changeValue(+2)}>+2</button>
    </div>
  );
};

export default MainComponent;