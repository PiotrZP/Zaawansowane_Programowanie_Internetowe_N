import { useState } from 'react';

function MyComponent() {
  const [name, setName] = useState('');

  const showName = () => {
    setName('Daniel Pająk');
  };

  return (
    <div>
      <p>{name || "Paragraf"}</p>
      <button onClick={showName}>Przycisk</button>
    </div>
  );
}

export default MyComponent;
