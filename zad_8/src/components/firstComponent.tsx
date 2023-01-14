import React, { useState } from 'react';
import SecondComponent from './secondComponent';

const FirstComponent: React.FC = () => {
  const [showSecond, setShowSecond] = useState(false);

  return (
    <div>
      <button onClick={() => setShowSecond(true)}>Pokaż pierwszy komponent</button>
      {showSecond && <SecondComponent message='Komunikat' />}
    </div>

    
  );
};

export default FirstComponent;

