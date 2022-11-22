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
  
  const FavLinks = () => {
    const links = [
      {
        name: "Binance",
        link: "https://www.binance.com",
      },
      {
        name: "Kucoin",
        link: "https://www.kucoin.com/",
      },
      {
        name: "Coinbase",
        link: "https://www.coinbase.com/",
      },
      {
        name: "Kraken",
        link: "https://www.kraken.com/",
      },
      {
        name: "coinmarketcap",
        link: "https://coinmarketcap.com/",
      },
      {
        name: "Coingecko",
        link: "https://www.coingecko.com/",
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