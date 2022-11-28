import { useCallback, useMemo, useState } from "react";
import CustomTabItem from "./CustomTabItem";
import CustomTabProps from "./CustomTabProps";
import "./CustomTab.css";

const CustomTab = (props: CustomTabProps) => {
  const tabItems: CustomTabItem[] = useMemo(
    () => [
      {
        id: 1,
        name: "Lista",
        child: props.listComponent,
      },
      {
        id: 2,
        name: "Dodawanie",
        child: props.addComponent,
      },
      {
        id: 3,
        name: "Edycja",
        child: props.editComponent,
      },
      {
        id: 4,
        name: "Usuwanie",
        child: props.deleteComponent,
      },
    ],
    [
      props.addComponent,
      props.deleteComponent,
      props.editComponent,
      props.listComponent,
    ]
  );

  const [activeTab, setActiveTab] = useState<CustomTabItem>(tabItems[0]);
  const isActive = useCallback(
    (tab: CustomTabItem) => activeTab.id === tab.id,
    [activeTab]
  );

  const child = useMemo(
    () =>
      activeTab ? tabItems.find((tab) => tab.id === activeTab.id)?.child : null,
    [activeTab, tabItems]
  );

  return (
    <div className="main-container">
      <div className="tabs-container">
        {tabItems.map((tab) => (
          <div
            onClick={() => setActiveTab(tab)}
            key={tab.id}
            className={isActive(tab) ? "tab-item-active" : "tab-item"}
          >
            {tab.name}
          </div>
        ))}
      </div>
      <div className="child-container">{child}</div>
    </div>
  );
};

export default CustomTab;
