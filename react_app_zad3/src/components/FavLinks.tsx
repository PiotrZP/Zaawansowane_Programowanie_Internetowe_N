import React, { FC, useState } from "react";
import "./FavLinks.css";

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

  return (
    <div className="container">
      {links.map((item) => (
        <Item name={item.name} link={item.link} />
      ))}
    </div>
  );
};

export default FavLinks;