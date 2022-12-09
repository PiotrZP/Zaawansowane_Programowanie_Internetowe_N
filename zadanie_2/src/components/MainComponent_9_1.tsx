import { useState } from "react";
import MainComponent_9_2 from './MainComponent_9_2';

const MainComponent = (): JSX.Element => {
  const [component, setComponent] = useState(false);
  return (
    <div>
      <p>{component}</p>
      <button onClick={() => setComponent(true)}>button</button>
      {component && <MainComponent_9_2 setComponent={setComponent}/>}
    </div>
  );
};

export default MainComponent;