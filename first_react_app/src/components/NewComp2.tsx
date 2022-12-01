import { useState } from 'react';
import './NewComp2.css';

function NewComp2() {
  const [name, set] = useState('');

  const show = () => {
    set('Krzysztof Habko');
  };

  return (
    <div>
        <h1 className='Zad'>Zadanie 2</h1>
        <p className='Par'>{name}</p>
        <button className='Button' onClick={show}>Check Name</button>
    </div>
  );
}

export default NewComp2;
