import React, { useMemo, useState } from "react";
import AddressView from "./address-view/AddressView";
import "./Dashboard.css";
import InvoiceView from "./invoice-view/InvoiceView";
import ProductView from "./product-view/ProductView";
import StoreView from "./store-view/StoreView";

enum Tabs {
  Address = 1,
  Product = 2,
  Invoice = 3,
  Stores = 4,
}

const Dashboard = () => {
  const [activeTab, setActiveTab] = useState<Tabs>(Tabs.Address);

  const component = useMemo(() => {
    switch (activeTab) {
      case Tabs.Address:
        return <AddressView />;
      case Tabs.Product:
        return <ProductView />;
      case Tabs.Invoice:
        return <InvoiceView />;
      case Tabs.Stores:
        return <StoreView />;
    }
  }, [activeTab]);

  const isActive = (tab: Tabs) => activeTab === tab;

  return (
    <div className="dashboard-container">
      <div className="side-bar">
        <div
          className={isActive(Tabs.Address) ? "menu-item-active" : "menu-item"}
          onClick={() => setActiveTab(Tabs.Address)}
        >
          Adresy
        </div>
        <div
          className={isActive(Tabs.Product) ? "menu-item-active" : "menu-item"}
          onClick={() => setActiveTab(Tabs.Product)}
        >
          Produkty
        </div>
        <div
          className={isActive(Tabs.Invoice) ? "menu-item-active" : "menu-item"}
          onClick={() => setActiveTab(Tabs.Invoice)}
        >
          Zamówienia
        </div>
        <div
          className={isActive(Tabs.Stores) ? "menu-item-active" : "menu-item"}
          onClick={() => setActiveTab(Tabs.Stores)}
        >
          Sklepy
        </div>
      </div>
      <div className="component-container">{component}</div>
    </div>
  );
};

export default Dashboard;
