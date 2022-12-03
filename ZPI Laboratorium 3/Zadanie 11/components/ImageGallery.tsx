import { images } from '../data/images';
import './ImageGallery.css';

interface ImageGalleryProps {
  changeImageIndex: (index: number) => void;
  currentImageIndex: number;
}

function ImageGallery({ changeImageIndex, currentImageIndex }: ImageGalleryProps) {
  return (
    <div className="image-gallery">
      <div className="gallery_container">
        {images.map((img, i) => (
          <img src={img} data-selected={i == currentImageIndex} onClick={() => changeImageIndex(i)} />
        ))}
      </div>
    </div>
  );
}

export default ImageGallery;

