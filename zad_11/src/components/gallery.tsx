import { useState } from "react";
import ImagePreview, { GalleryProps } from "./imagePreview";

const Gallery: React.FC<GalleryProps> = ({ images }) => {
    const [selectedImageId, setSelectedImageId] = useState(0);
    const [backgroundColor, setBackgroundColor] = useState('white');
  
    return (
      <div style={{ display: 'flex' }}>
        <div style={{ width: '50%', backgroundColor: '#f2f2f2' }}>
          {images.map((image) => (
            <div
              key={image.id}
              onClick={() => setSelectedImageId(image.id)}
              style={{
                backgroundColor:
                  image.id === selectedImageId ? backgroundColor : 'white',
                padding: '10px',
                cursor: 'pointer',
              }}
            >
              <img src={image.src} alt="thumbnail" style={{ width: '100%' }} />
            </div>
          ))}
        </div>
        <div style={{ width: '50%' }}>
          {selectedImageId !== 0 && (
            <ImagePreview
              src={
                images.find((image) => image.id === selectedImageId)?.src || ''
              }
            />
          )}
        </div>
      </div>
    );
  };

  export default Gallery