import { useState } from 'react';

export const Zadanie2 = () => {
  const [isButtonActive, setIsButtonActive] = useState<boolean>(false);

  return (
    <>
      <p>{isButtonActive && 'Bruno Cisowski'}</p>
      <button onClick={() => setIsButtonActive(true)}>Show my name</button>
    </>
  );
};
