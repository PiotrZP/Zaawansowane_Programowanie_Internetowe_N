import React, { useEffect, useRef, useState, FC } from "react";
import "./Photo.css";
import { photos } from "./Photos";
import Thumbnail from "./Thumbnail";

interface Photo {
    photo: string;
}

const Photo = () => {
    const [selectedPhoto, setSelectedPhoto] = useState("");
    const galleryThumbnailsRef = useRef() as React.MutableRefObject<HTMLDivElement>;

    const handleImageChange = (photo: string) => {
        setSelectedPhoto((prev) => (prev = photo));
    };

    useEffect(() => {
        const childrens = Array.from(galleryThumbnailsRef.current.children);
        childrens.forEach((item) => {
            let childAttr = item.attributes[1].textContent;
            if (childAttr !== selectedPhoto) {
                item.className = "gallery-thumbnail";
            }
        });
    }, [selectedPhoto]);

    const handleClearClassName = () => { };

    const Img: FC<Photo> = ({ photo }) => {
        return (
            <div className="gallery-photo-container">
                {photo !== "" && (
                    <img className="gallery-photo" src={photo} />
                )}
            </div>
        );
    };

    return (
        <div className="container">
            <div ref={galleryThumbnailsRef} className="gallery --thumbnails" onClick={handleClearClassName}>
                {photos.map((item, id) => (
                    <Thumbnail key={id} photo={item} click={handleImageChange} />
                ))}
            </div>
            <div className="gallery --selected"> <Img photo={selectedPhoto} />
            </div>
        </div>
    );
};

export default Photo;