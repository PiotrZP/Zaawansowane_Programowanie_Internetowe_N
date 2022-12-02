import React, { FC, useState, useRef } from "react";
import "./FavLinksMod.css";

interface ItemProps {
  name: string;
  link: string;
}

const Item: FC<ItemProps> = ({ name, link }) => {
  const [color, setColor] = useState(false);

  const handleOnClick = () => {
    setColor((prev) => !prev);
  };

  return (
    <>
      <a
        className={`${color === true ? "container-link colored" : "container-link"
          }`}
        href={link}
        target="blank"
        onClick={handleOnClick}
      >
        {name}
      </a>
    </>
  );
};

const FavLinks = () => {
  const links = [
    {
      name: "Niebezpiecznik",
      link: "https://www.niebezpiecznik.pl/",
    },
    {
      name: "Sekurak",
      link: "https://sekurak.pl/",
    },
    {
      name: "Zaufana Trzecia Strona",
      link: "https://www.zaufanatrzeciastrona.pl/",
    },
    {
      name: "WIRED",
      link: "https://www.wired.com/",
    },
    {
      name: "Stackoverflow",
      link: "https://stackoverflow.com/",
    },
    {
      name: "The Guardian",
      link: "https://www.theguardian.com/",
    },
  ];

  const containerRef = useRef() as React.MutableRefObject<HTMLDivElement>;

  const handleColorItem = () => {
    let table = Array.from(containerRef.current.children);
    table.forEach((item) => console.log((item.className = "container-link")));
    console.log(table);
  };

  return (
    <div ref={containerRef} className="container" onClick={handleColorItem}>
      {links.map((item, i) => (
        <Item key={i} name={item.name} link={item.link} />
      ))}
    </div>
  );
};

export default FavLinks;