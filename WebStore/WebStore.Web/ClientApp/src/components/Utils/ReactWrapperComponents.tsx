import React from "react";
import { AddressEdit } from "../address/AddressEdit";
import { ICrudComponent } from "./ICrudComponent";
import { AddressAdd } from "../address/AddressAdd";
import { AddressDelete } from "../address/AddressDelete";

type IProps = {
  nestedComponentType: ICrudComponent;
};

export const RouterWrapperComponent = (props: IProps) => {
  switch (props.nestedComponentType) {
    case AddressAdd:
      return <AddressAdd />;
    case AddressEdit:
      return <AddressEdit />;
    case AddressDelete:
      return <AddressDelete />;
  }
};
