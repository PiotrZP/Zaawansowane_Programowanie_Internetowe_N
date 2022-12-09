import { useState } from "react";
import MainComponent_10_2 from './MainComponent_10_2';

const MainComponent = (): JSX.Element => {
  const [component, setComponent] = useState(false);
  const [button, setButton] = useState(false);
  const [komunikat, setKomunikat] = useState("");
  if (button) {
    setKomunikat("Cieszę się! Idźmy dalej!");
  } else if (button == false) {
    //setKomunikat("Przykro mi, że się męczysz!");
  }
  return (
    <div>
      <button onClick={() => setComponent(true)}>button</button>
      {component && <MainComponent_10_2 setComponent={setComponent} setButton={setButton} />}
      <p>{komunikat}</p>
    </div>
  );
};

export default MainComponent;