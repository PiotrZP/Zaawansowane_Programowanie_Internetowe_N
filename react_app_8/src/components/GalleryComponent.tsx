import { useCallback, useMemo, useState } from "react";
import "./GalleryComponent.css";
import GalleryComponentProps from "./GalleryComponentProps";
import ImageBox from "./image-box/ImageBox";

const GalleryComponent = (props: GalleryComponentProps): JSX.Element => {
  const { images } = props;
  const [activeImageUrl, setActiveImageUrl] = useState("");

  useMemo(() => {
    if (!activeImageUrl && images.length > 0) setActiveImageUrl(images[0]);
  }, [activeImageUrl, images]);

  const isImageActive = useCallback(
    (url: string) => url === activeImageUrl,
    [activeImageUrl]
  );

  return (
    <div className="gc-main-container">
      <div className="gc-thumbnails-container">
        {images.map((image) => (
          <div key={image} className="gc-thumbnail">
            {!isImageActive(image) && (
              <img
                src={image}
                alt={image}
                width={64}
                height={64}
                onClick={() => setActiveImageUrl(image)}
              />
            )}
          </div>
        ))}
      </div>
      <div className="gc-image-container">
        {activeImageUrl && <ImageBox imageUrl={activeImageUrl} />}
      </div>
    </div>
  );
};

export default GalleryComponent;
