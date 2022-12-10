import { useState } from 'react';
import { Drugi } from './Drugi';
import { Pierwszy } from './Pierwszy';

export const Zadanie10 = () => {
  const [showSecond, setShowSecond] = useState<boolean>(false);
  const [secondResp, setSecondResp] = useState<boolean | null>(null);

  return (
    <>
      <Pierwszy onBtnClick={() => setShowSecond(true)} />
      {showSecond && (
        <Drugi
          onBtnClick={(boolean) => {
            setShowSecond(false);
            setSecondResp(boolean);
          }}
        />
      )}
      {(secondResp === true && <p>Cieszę się! Idźmy dalej!</p>) ||
        (secondResp === false && <p>Przykro mi, że się męczysz!"</p>)}
    </>
  );
};
