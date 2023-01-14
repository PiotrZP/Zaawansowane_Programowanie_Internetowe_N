import React, { useState } from 'react';

interface Props {
    name: string;
    surname: string;
}

const MyName: React.FC<Props> = ({ name, surname }) => {
  const [showName, setShowName] = useState(false);

  return (
    <div>
      <p>{showName ? `${name} ${surname}` : ''}</p>
      <button onClick={() => setShowName(!showName)}>
        Pokaż imię
      </button>
    </div>
  );
}

export default MyName;