import React, { useState } from "react";
import "./Zad11.css";
import Zad11_foto from "./Zad11_foto";

const myLinks = [
  "../..//assets/1.jpg",
  "../..//assets/2.jpg",
  "../..//assets/3.jpg",
  "../..//assets/4.jpg",
];

const Zad11 = () => {
  const [value, setValue] = useState<string>();
  const Background = (image: string) => {
    setValue(image);
  };

  return (
    <div className="menu">
      <div>
        {myLinks.map((link) => (
          <div className="color">
            {link !== value && (
              <img
                onClick={() => Background(link)}
                width={60}
                height={60}
                src={link}
                alt={link}
              />
            )}
          </div>
        ))}
      </div>
      <div>{value && <Zad11_foto value={value} />}</div>
    </div>
  );
};

export default Zad11;
