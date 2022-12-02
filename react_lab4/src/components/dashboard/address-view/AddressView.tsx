import CustomHeader from "../../common/custom-header/CustomHeader";
import CustomTab from "../../common/custom-tab/CustomTab";
import AddressAdd from "./components/address-add/AddressAdd";
import AddressDelete from "./components/address-delete/AddressDelete";
import AddressEdit from "./components/address-edit/AddressEdit";
import AddressList from "./components/address-list/AddressList";
import "./AddressView.css";

const AddressView = () => {
  return (
    <div className="address-main-container">
      <CustomHeader title="Adresy" />
      <CustomTab
        listComponent={<AddressList />}
        addComponent={<AddressAdd />}
        editComponent={<AddressEdit />}
        deleteComponent={<AddressDelete />}
      />
    </div>
  );
};

export default AddressView;
