import { useState } from 'react';
import './MyComponent.css';
import NewComponent from './NewComponent';

function MyComponent() {
  const [showComponent, setShowComponent] = useState(false);

  return (
    <div className="my-component">
      {showComponent && <NewComponent hide={() => setShowComponent(false)}/>}
      <br />
      <button onClick={() => setShowComponent(true)}>Pokaż nowy komponent</button>
    </div>
  );
}

export default MyComponent;

