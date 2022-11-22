import React, { FC, useEffect, useRef, useState } from "react";
import "./Zad11.css";
import { zdjecia } from "./zdj/images";

interface MiniatureProps {
  image: string;
  click: (image: string) => void;
}
interface ImgProps {
  image: string;
}

const Miniature: FC<MiniatureProps> = ({ image, click }) => {
  const handleChose = (e: React.SyntheticEvent<HTMLImageElement>) => {
    click(image);
    e.currentTarget.className = "twix-miniature --chosen";
  };

  return (
    <>
      <img
        className="twix-miniature"
        src={image}
        alt="brak opisu"
        onClick={handleChose}
      />
    </>
  );
};

const Img: FC<ImgProps> = ({ image }) => {
  return (
    <div className="twix-image-container">
      {image !== "" && (
        <img className="twix-image" src={image} alt="brak opisu" />
      )}
    </div>
  );
};

const Zad11 = () => {
  const [currentImg, setCurrentImg] = useState("");
  const leftTwixRef = useRef() as React.MutableRefObject<HTMLDivElement>;

  const handleImageChange = (image: string) => {
    setCurrentImg((prev) => (prev = image));
  };

  useEffect(() => {
    const childrens = Array.from(leftTwixRef.current.children);
    childrens.forEach((item) => {
      let childAttr = item.attributes[1].textContent;
      if (childAttr !== currentImg) {
        item.className = "twix-miniature";
      }
    });
  }, [currentImg]);

  const handleClearClassName = () => {};

  return (
    <div className="container">
      <div
        ref={leftTwixRef}
        className="twix --lewy"
        onClick={handleClearClassName}
      >
        {zdjecia.map((item, id) => (
          <Miniature key={id} image={item} click={handleImageChange} />
        ))}
      </div>
      <div className="twix --prawy">
        <Img image={currentImg} />
      </div>
    </div>
  );
};

export default Zad11;
