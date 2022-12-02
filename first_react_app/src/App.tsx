import { useState } from 'react';
import './App.css';
import NewComp8 from './components/NewComp8';
import NextComp from './components/NextComp';

function App() {
  const [show, setShow] = useState(false);



  return (
    <div className="App">
      <NewComp8></NewComp8>
      {show && <NextComp></NextComp>}
      <button className='Button' onClick={() => setShow(true)}>Wyswietl Drugi</button>
    </div>
  );
}

export default App;

