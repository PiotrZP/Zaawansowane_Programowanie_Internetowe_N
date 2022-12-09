import { useState, useMemo, useCallback } from "react";
import IGallery from "../model/IGallery";
import Display from "./Display";
import "../styles/Gallery.css";

const Gallery = (props: IGallery) => {
  const { images } = props;
  const [displayUrl, setDisplayUrl] = useState("");

  useMemo(() => {
    if (!displayUrl && images.length > 0) setDisplayUrl(images[0]);
  }, [displayUrl, images]);

  const isDisplayd = useCallback(
    (url: string) => url === displayUrl,
    [displayUrl]
  );

  return (
    <div className="main">
      <div className="gallery">
        {images.map((image) => (
          <div key={image} className="thumbnail">
            {!isDisplayd(image) && (
              <img
                width={64}
                height={48}
                onClick={() => setDisplayUrl(image)}
                src={image}
                alt={image}
              />
            )}
          </div>
        ))}
      </div>
      <div className="display">
        {displayUrl && <Display url={displayUrl} />}
      </div>
    </div>
  );
};

export default Gallery;
