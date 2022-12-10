import { AddressEdit } from "../Address/AddressEdit"
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import React from "react";
import { ICrudComponent } from "./ICrudComponent";
import { AddressAdd } from "../Address/AddressAdd";
import { AddressDelete } from "../Address/AddressDelete";
type IProps = {
nestedComponentType: ICrudComponent
}
export const RouterWrapperComponent = (props: IProps) => {
const navigate = useNavigate()
const params = useParams();
switch (props.nestedComponentType) {
case AddressAdd:
return <AddressAdd navigate={navigate} params={params} {...props} />
case AddressEdit:
return <AddressEdit navigate={navigate} params={params} {...props} />
case AddressDelete:
return <AddressDelete navigate={navigate} params={params} {...props} />
}
}