import styled from "@emotion/styled";
import { TableCell } from "@mui/material";

export const PlMainContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 24px;
  align-items: flex-end;
  & > * {
    padding: 12px;
  }
`;

export const PlCell = styled(TableCell)`
  min-width: 100px;
  align-items: center;
  justify-content: center;
  display: flex;
`;
