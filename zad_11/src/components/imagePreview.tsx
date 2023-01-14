import React, { useState } from 'react';

export interface GalleryProps {
  images: {
    id: number;
    src: string;
  }[];
}

interface ImagePreviewProps {
  src: string;
}

const ImagePreview: React.FC<ImagePreviewProps> = ({ src }) => {
  return <img src={src} alt="preview" style={{ width: '100%' }} />;
};

export default ImagePreview