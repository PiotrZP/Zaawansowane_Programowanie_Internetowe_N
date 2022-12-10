import { useState } from 'react';
import styled from 'styled-components';
import first from '../img/first.webp';
import second from '../img/second.webp';

interface StyledImgTilesProps {
  isActive: boolean;
}

const StyledContainer = styled.div`
  display: flex;
`;
const StyledImgTiles = styled.div<StyledImgTilesProps>`
  max-width: 100px;
  border: ${({ isActive }) => isActive && '2px solid red'};
  img {
    width: 100%;
    height: auto;
  }
`;
const StyledImgPreview = styled.div`
  max-width: 200px;
  img {
    width: 100%;
    height: auto;
  }
`;

export const Zadanie11 = () => {
  const [activeImg, setActiveImg] = useState<number>(0);
  const imgs: string[] = [first, second];
  return (
    <StyledContainer>
      <div>
        {imgs.map((img, i) => (
          <StyledImgTiles
            onClick={() => setActiveImg(i)}
            isActive={activeImg === i}
          >
            <img src={img} />
          </StyledImgTiles>
        ))}
      </div>
      <StyledImgPreview>
        <img src={imgs[activeImg]} />
      </StyledImgPreview>
    </StyledContainer>
  );
};
