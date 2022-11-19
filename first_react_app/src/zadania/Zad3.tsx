import React, { FC, useState } from "react";
import "./Zad3.css";

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
        className={`${
          color === true ? "container-link colored" : "container-link"
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

const Zad3 = () => {
  const links = [
    {
      name: "Youtube",
      link: "https://www.youtube.com/",
    },
    {
      name: "Facebook",
      link: "https://www.facebook.com/",
    },
    {
      name: "W3schools",
      link: "https://www.w3schools.com/",
    },
    {
      name: "Reddit",
      link: "https://www.reddit.com/",
    },
    {
      name: "Github",
      link: "https://github.com/",
    },
    {
      name: "Netflix",
      link: "https://www.netflix.com/",
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

export default Zad3;
