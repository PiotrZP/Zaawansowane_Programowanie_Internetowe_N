import React from 'react';
import MyName from './components/MyName';
const App: React.FC = () => {
  return (
    <div className="App">
      <MyName name="Michał" surname="Zymek" />
    </div>
  );
}

export default App;