import { useState } from "react";
import MainComponent_10_2Props from "./MainComponent_10_2Props";

const MainComponent = (props: MainComponent_10_2Props): JSX.Element => {
  const {setComponent} = props;
  const {setButton} = props;
  return (
    <div>
      <p>Czy chcesz dalej się uczyć bilbioteki React?</p>
      <button onClick={()=>{setComponent(false); setButton(true)}}>TAK</button>
      <button onClick={()=>{setComponent(false); setButton(false)}}>NIE</button>
    </div>
  );
};

export default MainComponent;