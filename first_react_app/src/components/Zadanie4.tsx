import { MouseEvent, useState } from 'react';

export const Zadanie4 = () => {
  const links = [
    {
      id: 1,
      name: 'Wirtualna Polska',
      url: 'https://www.wp.pl/',
    },
    {
      id: 2,
      name: 'Onet',
      url: 'https://www.onet.pl/',
    },
  ];
  const [clickedLink, setClickedLink] = useState<number | null>(null);

  return (
    <ul>
      {links.map(({ id, name, url }) => (
        <li>
          <a
            href={url}
            onClick={(e: MouseEvent<HTMLAnchorElement>) => {
              e.preventDefault();
              setClickedLink(id);
            }}
            style={clickedLink === id ? { backgroundColor: 'red' } : {}}
          >
            {name}
          </a>
        </li>
      ))}
    </ul>
  );
};
