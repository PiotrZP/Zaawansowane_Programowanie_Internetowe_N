import React, { SetStateAction } from "react";

export default interface INextProps {
  toggleComponent: React.Dispatch<SetStateAction<boolean>>;
}
