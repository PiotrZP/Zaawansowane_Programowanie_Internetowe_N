import { useState } from "react";
import MainComponent_9_2Props from "./MainComponent_9_2Props";


const MainComponent = (props: MainComponent_9_2Props): JSX.Element => {
  const {setComponent} = props;
  return (
    <div>
      <button onClick={()=>setComponent(false)}>ukryj</button>
    </div>
  );
};

export default MainComponent;