import { images } from '../data/images';
import './ImagePreview.css';

interface ImagePreviewProps {
  currentImageIndex: number;
}

function ImagePreview(props: ImagePreviewProps) {
  return (
    <div className="image-preview">
      <div className="preview_container">
        <img className="preview-fg" src={images[props.currentImageIndex]} alt="image 1" />
      </div>
    </div>
  );
}

export default ImagePreview;

