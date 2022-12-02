import React, { FC } from "react";
import "./Miniaturka.css";


interface Miniatura {
  image: string;
  click: (image: string) => void;
}


const Miniaturka: FC<Miniatura> = ({ image, click }) => {
  const handleChose = (e: React.SyntheticEvent<HTMLImageElement>) => {
    click(image);
    e.currentTarget.className = "gallery-miniature --chosen";
  };

  return (
    <>
      <img
        className="gallery-miniature"
        src={image}
        alt="brak opisu"
        onClick={handleChose}
      />
    </>
  );
};



export default Miniaturka;