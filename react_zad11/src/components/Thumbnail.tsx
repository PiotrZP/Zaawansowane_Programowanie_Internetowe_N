import React, { FC } from "react";
import "./Thumbnail.css";


interface Thumbnail {
  photo: string;
  click: (photo: string) => void;
}


const Thumbnail: FC<Thumbnail> = ({ photo, click }) => {
  const handleChose = (e: React.SyntheticEvent<HTMLImageElement>) => {
    click(photo);
    e.currentTarget.className = "gallery-thumbnail selected";
  };

  return (
    <>
      <img className="gallery-thumbnail" src={photo} alt="brak opisu" onClick={handleChose} />
    </>
  );
};

export default Thumbnail;