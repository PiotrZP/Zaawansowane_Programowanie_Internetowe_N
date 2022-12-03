import { useState } from 'react';

import './MyComponent.css';

const favoriteLinks = [
  {
    name: 'Github',
    href: 'https://github.com/Spythere',
  },
  {
    name: 'Moodle',
    href: 'https://moodle2022.pcz.pl',
  },
  {
    name: 'YouTube',
    href: 'https://www.youtube.com/',
  },
  {
    name: 'Margonem',
    href: 'https://www.margonem.pl',
  },
];

function MyComponent() {
  const [chosenIndexes, setChosenIndexes] = useState<number[]>([]);

  const toggleIndex = (index: number) => {
    if (chosenIndexes.includes(index)) return setChosenIndexes(chosenIndexes.filter((i) => i !== index));

    return setChosenIndexes([...chosenIndexes, index]);
  };

  return (
    <div>
      <ul>
        {favoriteLinks.map((link, i) => (
          <li data-selected={chosenIndexes.includes(i)} onClick={() => toggleIndex(i)}>
            {link.name}: {link.href}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default MyComponent;

