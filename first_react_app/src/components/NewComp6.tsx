import { useState } from 'react';
import './NewComp6.css';

function NewComp6() {
  const [num, setNum] = useState<number>(0);


  return (
    <div>
      <p className='Par'>{0 || num}</p>
        <div>
          <button className='Button' onClick={() => setNum(num -1)}>
            -1
          </button>
          <button className='Button' onClick={() => setNum(num +1)}>
            +1
          </button>
        </div>
        <div>
          <button className='Button' onClick={() => setNum(num -2)}>
            -2
          </button>
          <button className='Button' onClick={() => setNum(num +2)}>
            +2
          </button>
        </div>     
    </div>
    
  );
}

export default NewComp6;

