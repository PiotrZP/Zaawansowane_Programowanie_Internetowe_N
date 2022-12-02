import { useState } from 'react';
import './NewComp4.css';

const links = [
  {id:1,link:'https://www.netflix.com',name:'Netflix'},
  {id:2,link:'https://www.nature.com',name:'Nature'},
  {id:3,link:'https://www.circuitcellar.com',name:'Circuitcellar'},
  {id:4,link:'https://www.github.com',name:'Github'}
];

function NewComp4() {
  const [Id, setId] = useState<number>();

  const toggle = (idnum: number) => {
    if (Id == idnum) 
      return setId(-1);

    return setId(idnum);
  };

  return (
    <div>
      <ul>
        {links.map((l, i) => (
          <li data-selected={Id == i} onClick={() => toggle(i)}>
            {l.id} : {l.name}  {l.link}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default NewComp4;

