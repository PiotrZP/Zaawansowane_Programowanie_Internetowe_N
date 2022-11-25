import React from "react";
import Zad11_foto_props from "./Zad11_foto_props";

const Zad11_foto = (props: Zad11_foto_props) => {
  return <img src={props.value} width={640} height={480} />;
};

export default Zad11_foto;
