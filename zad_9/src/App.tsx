import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import SecondComponent from './components/components/secondComponent';

function App() {
  const [showSecond, setShowSecond] = useState(false);

  return (
    <div>
      <button onClick={() => setShowSecond(true)}>
        Pokaż drugi komponent
      </button>
      {showSecond && <SecondComponent />}
    </div>
  );
};


export default App;
