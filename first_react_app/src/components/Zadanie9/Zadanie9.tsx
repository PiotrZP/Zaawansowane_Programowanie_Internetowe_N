import { useState } from 'react';
import { Drugi } from './Drugi';
import { Pierwszy } from './Pierwszy';

export const Zadanie9 = () => {
  const [showSecond, setShowSecond] = useState<boolean>(false);

  return (
    <>
      <Pierwszy onBtnClick={() => setShowSecond(true)} />
      {showSecond && <Drugi onBtnClick={() => setShowSecond(false)} />}
    </>
  );
};
