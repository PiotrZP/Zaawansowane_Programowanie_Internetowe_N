import { useState } from 'react';
import './NewComp7.css';

const samples = [
  'https://picsum.photos/300/300.jpg?random=1',
  'https://picsum.photos/300/300.jpg?random=2',
  'https://picsum.photos/300/300.jpg?random=3',
  'https://picsum.photos/300/300.jpg?random=4',
  'https://picsum.photos/300/300.jpg?random=5',
  'https://picsum.photos/300/300.jpg?random=6',
  'https://picsum.photos/300/300.jpg?random=7',
  'https://picsum.photos/300/300.jpg?random=8',
  'https://picsum.photos/300/300.jpg?random=9',
  'https://picsum.photos/300/300.jpg?random=10'
];
function NewComp7() {
  
  const [Img, setImg] = useState(0);

  const previous = () => {
    if (Img == 0){
      return alert("Pierwsze Zdjęcie");
    }
    setImg(Img -1);
  }
  const next = () => {
    if (Img == samples.length -1){
      return alert("Ostatnie Zdjęcie");
    }
    setImg(Img +1);
  }
  
  return (
    <div>
      <img src={samples[Img]}></img>
      <div>
        <button className='Button' onClick={previous}>Poprzednie</button>
        <button className='Button' onClick={next}>Następne</button>
      </div>
      
    </div>
  );
}

export default NewComp7;

