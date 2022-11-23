import { useState } from 'react';
import './MyComponent.css';
import NewComponent from './NewComponent';

function MyComponent() {
  const [showComponent, setShowComponent] = useState(false);
  const [response, setResponse] = useState('');

  return (
    <div className="my-component">
      {showComponent && !response && <NewComponent showResponse={(resp) => setResponse(resp)} />}
      <br />
      {response || showComponent ? (
        <h2>{response}</h2>
      ) : (
        <button onClick={() => setShowComponent(true)}>Pokaż komponent</button>
      )}
    </div>
  );
}

export default MyComponent;


