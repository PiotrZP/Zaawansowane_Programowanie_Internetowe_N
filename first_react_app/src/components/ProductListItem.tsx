import { FC } from "react";
import styled from "styled-components";
import { IProduct } from "../App";

const StyledContainer = styled.div``;
const StyledElement = styled.div`
  margin-bottom: 30px;
`;
const StyledLabel = styled.label``;
const StyledSpan = styled.span`
  display: block;
`;

export const ProductListItem: FC<IProduct> = ({ id, name, price, type }) => {
  return (
    <StyledContainer>
      <StyledElement>
        <StyledLabel>Id</StyledLabel>
        <StyledSpan>{id}</StyledSpan>
      </StyledElement>
      <StyledElement>
        <StyledLabel>Name</StyledLabel>
        <StyledSpan>{name}</StyledSpan>
      </StyledElement>
      <StyledElement>
        <StyledLabel>Price</StyledLabel>
        <StyledSpan>{price}</StyledSpan>
      </StyledElement>
      <StyledElement>
        <StyledLabel>Type</StyledLabel>
        <StyledSpan>{type}</StyledSpan>
      </StyledElement>
    </StyledContainer>
  );
};
