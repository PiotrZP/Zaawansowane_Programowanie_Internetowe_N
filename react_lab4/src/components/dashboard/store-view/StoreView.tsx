import CustomHeader from "../../common/custom-header/CustomHeader";
import CustomTab from "../../common/custom-tab/CustomTab";
import StoreAdd from "./components/store-add/StoreAdd";
import StoreDelete from "./components/store-delete/StoreDelete";
import StoreEdit from "./components/store-edit/StoreEdit";
import StoreList from "./components/store-list/StoreList";
import "./StoreView.css";

const StoreView = () => {
  return (
    <div className="store-main-container">
      <CustomHeader title="Sklepy" />
      <CustomTab
        listComponent={<StoreList />}
        addComponent={<StoreAdd />}
        editComponent={<StoreEdit />}
        deleteComponent={<StoreDelete />}
      />
    </div>
  );
};

export default StoreView;
