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
  const [chosenIndex, setChosenIndex] = useState<number>(-1);

  const toggleIndex = (index: number) => {
    if (chosenIndex == index) return setChosenIndex(-1);

    return setChosenIndex(index);
  };

  return (
    <div>
      <ul>
        {favoriteLinks.map((link, i) => (
          <li data-selected={chosenIndex == i} onClick={() => toggleIndex(i)}>
            {link.name}: {link.href}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default MyComponent;

