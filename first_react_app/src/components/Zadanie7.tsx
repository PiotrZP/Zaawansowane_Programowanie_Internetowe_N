import { useState } from 'react';
import styled from 'styled-components';
import first from '../img/first.webp';
import second from '../img/second.webp';

const StyledImg = styled.img`
  max-width: 200px;
`;

export const Zadanie7 = () => {
  const imgs = [first, second];
  const [activeGalleryIndex, setActiveGalleryIndex] = useState<number>(0);
  const [info, setInfo] = useState<string>('');
  const handleGallery = (type: string) => {
    if (type === 'increment') {
      if (activeGalleryIndex === imgs.length - 1) {
        setInfo('Jest to ostatnie zdjęcie i nie może być wyświetlone następne');
      } else {
        setInfo('');
        setActiveGalleryIndex(
          (prevActiveGalleryIndex) => ++prevActiveGalleryIndex
        );
      }
    }
    if (type === 'decrement') {
      if (activeGalleryIndex === 0) {
        setInfo(
          'Jest to pierwsze zdjęcie i nie może być wyświetlone wcześniejsze'
        );
      } else {
        setInfo('');
        setActiveGalleryIndex(
          (prevActiveGalleryIndex) => --prevActiveGalleryIndex
        );
      }
    }
  };

  return (
    <>
      <StyledImg src={imgs[activeGalleryIndex]} />
      <button onClick={() => handleGallery('decrement')}>Previous</button>
      <button onClick={() => handleGallery('increment')}>Next</button>
      {info && <p>{info}</p>}
    </>
  );
};
