import { ChangeEvent, FC, FormEvent, useState } from "react";
import styled from "styled-components";
import { IProduct } from "../App";

interface IAddProductToListProps {
  submit: (product: IProduct) => void;
}

const StyledFormContainer = styled.div``;
const StyledForm = styled.form``;
const StyledElement = styled.div``;
const StyledInput = styled.input``;
const StyledButton = styled.button``;

export const AddProductToList: FC<IAddProductToListProps> = ({ submit }) => {
  const [products, setProducts] = useState<IProduct>({
    id: 0,
    name: "",
    type: "",
    price: 0,
  });
  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const newProducts = { ...products } as any;
    newProducts[e.target.name] = e.target.value;
    setProducts(newProducts);
  };
  const handleFormSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    submit(products);
  };
  return (
    <StyledFormContainer>
      <StyledForm onSubmit={handleFormSubmit}>
        <StyledElement>
          <StyledInput
            type="text"
            name="id"
            placeholder="id"
            onChange={handleInputChange}
            value={products.id}
          />
        </StyledElement>
        <StyledElement>
          <StyledInput
            type="text"
            name="name"
            placeholder="name"
            onChange={handleInputChange}
            value={products.id}
          />
        </StyledElement>
        <StyledElement>
          <StyledInput
            type="text"
            name="type"
            placeholder="type"
            onChange={handleInputChange}
            value={products.id}
          />
        </StyledElement>
        <StyledElement>
          <StyledInput
            type="text"
            name="price"
            placeholder="price"
            onChange={handleInputChange}
            value={products.id}
          />
        </StyledElement>
        <StyledButton type="submit">Add</StyledButton>
      </StyledForm>
    </StyledFormContainer>
  );
};
