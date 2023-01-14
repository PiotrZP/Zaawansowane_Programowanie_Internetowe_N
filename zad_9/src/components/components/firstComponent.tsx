import React, { useState } from 'react';

interface FirstComponentProps {
  onClose: () => void;
}

const FirstComponent: React.FC<FirstComponentProps> = ({ onClose }) => {
  return (
    <div>
      <button onClick={() => onClose()}>Zamknij drugi komponent</button>
    </div>
  );
};
export default FirstComponent;

