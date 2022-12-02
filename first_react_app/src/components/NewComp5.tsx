import { useState } from 'react';
import './NewComp5.css';

function NewComp5() {
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
    </div>
    
  );
}

export default NewComp5;

