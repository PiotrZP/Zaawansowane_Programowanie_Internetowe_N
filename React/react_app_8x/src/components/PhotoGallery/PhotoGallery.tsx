import React, { useState } from 'react';
import { PhotoGalleryProps } from './PhotoGalleryProps';
import { PhotoProps } from './PhotoProps';
import { ThumbnailProps } from './ThumbnailProps';

// Import the styles for the components
import './PhotoGallery.css';

// Define the Photo component
const Photo: React.FC<PhotoProps> = ({ src, color }) => {
  return (
    <div className="photo">
      <img src={src} alt="Photo" style={{ background: color }} />
    </div>
  );
};

// Define the Thumbnail component
const Thumbnail: React.FC<ThumbnailProps> = ({ src, onClick }) => {
  return (
    <div className="thumbnail">
      <img src={src} alt="Thumbnail" onClick={onClick} />
    </div>
  );
};

// Define the PhotoGallery component
const PhotoGallery: React.FC<PhotoGalleryProps> = ({ photos }) => {
  // Use state to track the selected photo and its color
  const [selectedPhoto, setSelectedPhoto] = useState<string>('');
  const [selectedPhotoColor, setSelectedPhotoColor] = useState<string>('');

  // Define a function for selecting a photo
  const selectPhoto = (src: string, color: string) => {
    setSelectedPhoto(src);
    setSelectedPhotoColor(color);
  };

  return (
    <div className="photo-gallery">
      <div className="photo-thumbnails">
        {photos.map(photo => (
          <Thumbnail
            src={photo.src}
            onClick={() => selectPhoto(photo.src, photo.color)}
          />
        ))}
      </div>
      {selectedPhoto && (
        <Photo src={selectedPhoto} color={selectedPhotoColor} />
      )}
    </div>
  );
};

export default PhotoGallery;