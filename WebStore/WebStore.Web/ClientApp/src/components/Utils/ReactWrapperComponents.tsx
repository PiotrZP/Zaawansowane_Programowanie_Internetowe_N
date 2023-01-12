import { AddressEdit } from "../Address/AddressEdit";

import React from "react";
import { ICrudComponent } from "./ICrudComponent";
import { AddressAdd } from "../Address/AddressAdd";
import { AddressDelete } from "../Address/AddressDelete";

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
