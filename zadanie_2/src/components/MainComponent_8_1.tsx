import { useState } from "react";
import MainComponent_8_2 from './MainComponent_8_2';

const MainComponent = (): JSX.Element => {
  const [component, setComponent] = useState(false);
  return (
    <div>
      <p>{component}</p>
      <button onClick={() => setComponent(true)}>button</button>
      {component && <MainComponent_8_2/>}
    </div>
  );
};

export default MainComponent;