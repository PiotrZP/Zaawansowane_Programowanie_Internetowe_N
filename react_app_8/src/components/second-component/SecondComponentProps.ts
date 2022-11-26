import React, { SetStateAction } from "react";

export interface SecondComponentProps {
  toggleComponent: React.Dispatch<SetStateAction<boolean>>;
}