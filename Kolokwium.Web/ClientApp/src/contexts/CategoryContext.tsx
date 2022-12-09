import React, { useState } from "react";
import axios from "axios";
import { ICategory } from "../models/ICategory";

const CategoryContext = React.createContext({});

export const CategoryProvider = ({ children }: { children: React.ReactNode }) => {
  const [state, setState] = useState<{ categories: ICategory[] }>({ categories: [] });

  const getCategories = async () => {
    const response = await axios.get<ICategory[]>("/api/CategoryApi");
    setState({ categories: response.data });
  };

  return (
    <CategoryContext.Provider
      value={{
        state,
        getCategories,
      }}
    >
      {children}
    </CategoryContext.Provider>
  );
};

export default CategoryContext;



