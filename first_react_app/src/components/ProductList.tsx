import { ChangeEvent, FC, useState } from "react";
import styled from "styled-components";
import { IProduct } from "../App";
import { AddProductToList } from "./AddProductToList";
import { ProductListItem } from "./ProductListItem";

const StyledContainer = styled.div``;
const StyledInputContainer = styled.div``;
const StyledInput = styled.input``;
const StyledSpanContainer = styled.span``;
const StyledSpan = styled.span``;
const StyledList = styled.div``;

interface IProductListProps {
  products: Array<IProduct>;
}

export const ProductList: FC<IProductListProps> = ({ products }) => {
  const [products, setProducts] = useState([]);
  const [inputValue, setInputValue] = useState<string>("");
  const handleAddNewProduct = (product: IProduct) => {
    setProducts((prevProducts: Array<IProduct>) => [...prevProducts, product]);
  };

  return (
    <StyledContainer>
      <StyledInputContainer>
        <StyledInput
          type="text"
          onChange={(e: ChangeEvent<HTMLInputElement>) =>
            setInputValue(e.target.value)
          }
        />
      </StyledInputContainer>
      <StyledSpanContainer>
        <StyledSpan>{inputValue}</StyledSpan>
      </StyledSpanContainer>
      <StyledList>
        {inputValue &&
          products.map(({ id, name, type, price }) => (
            <ProductListItem
              id={id}
              key={id}
              name={name}
              type={type}
              price={price}
            />
          ))}
      </StyledList>
      <AddProductToList submit={handleAddNewProduct} />
    </StyledContainer>
  );
};
