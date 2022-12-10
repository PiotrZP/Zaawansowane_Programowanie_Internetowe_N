import React, { SetStateAction } from "react";

export default interface INext {
  toggleComponent: React.Dispatch<SetStateAction<boolean>>;
}
