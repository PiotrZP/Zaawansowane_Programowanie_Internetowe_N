import React, { useState } from 'react';
import SecondComponent from './secondComponent';

const FirstComponent: React.FC = () => {
  const [showSecond, setShowSecond] = useState(false);
  const [message, setMessage] = useState('');

  const handleClick = (response: string) => {
    setShowSecond(false);
    if (response === "Tak") {
      setMessage("Cieszę się! Idźmy dalej!");
    } else {
      setMessage("Przykro mi, że się męczysz!");
    }
  }

  return (
    <div>
      <button onClick={() => setShowSecond(true)}>Pokaż pierwszy komponent</button>
      {showSecond && <SecondComponent onClick={handleClick} />}
      {message && <p>{message}</p>}
    </div>
  );
};

export default FirstComponent;

