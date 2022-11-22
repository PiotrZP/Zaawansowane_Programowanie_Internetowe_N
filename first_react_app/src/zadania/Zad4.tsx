import React, { FC, useState, useRef } from "react";
import "./Zad4.css";

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

const Zad4 = () => {
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

export default Zad4;
