import React, { useEffect, useRef, useState,FC } from "react";
import "./Zdjecie.css";
import { images } from "./images";
import Miniaturka from "./Miniaturka";

interface Image {
    image: string;
  }

const Gallery = () => {
    const [currentImg, setCurrentImg] = useState("");
    const leftGalleryRef = useRef() as React.MutableRefObject<HTMLDivElement>;

    const handleImageChange = (image: string) => {
        setCurrentImg((prev) => (prev = image));
    };

    useEffect(() => {
        const childrens = Array.from(leftGalleryRef.current.children);
        childrens.forEach((item) => {
            let childAttr = item.attributes[1].textContent;
            if (childAttr !== currentImg) {
                item.className = "gallery-miniature";
            }
        });
    }, [currentImg]);

    const handleClearClassName = () => { };

    const Img: FC<Image> = ({ image }) => {
        return (
          <div className="gallery-image-container">
            {image !== "" && (
              <img className="gallery-image" src={image} alt="brak opisu" />
            )}
          </div>
        );
      };

    return (
        <div className="container">
            <div
                ref={leftGalleryRef}
                className="gallery --lewy"
                onClick={handleClearClassName}
            >
                {images.map((item, id) => (
                    <Miniaturka key={id} image={item} click={handleImageChange} />
                ))}
            </div>
            <div className="gallery --prawy">
                <Img image={currentImg} />
            </div>
        </div>
    );
};

export default Gallery;