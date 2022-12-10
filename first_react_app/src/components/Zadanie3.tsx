import { MouseEvent, useState } from "react";

export const Zadanie3 = () => {
  const links = [
    {
      id: 1,
      name: "Wirtualna Polska",
      url: "https://www.wp.pl/",
    },
    {
      id: 2,
      name: "Onet",
      url: "https://www.onet.pl/",
    },
  ];
  const [clickedLinks, setClickedLinks] = useState<number[]>([]);

  return (
    <ul style={{ listStyle: "none" }}>
      {links.map(({ id, name, url }) => (
        <li>
          <a
            href={url}
            onClick={(e: MouseEvent<HTMLAnchorElement>) => {
              e.preventDefault();
              setClickedLinks((prevClickedLinks) => [...prevClickedLinks, id]);
            }}
            style={clickedLinks.includes(id) ? { backgroundColor: "red" } : {}}
          >
            {name}
          </a>
        </li>
      ))}
    </ul>
  );
};
