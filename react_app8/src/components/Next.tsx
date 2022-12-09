import React from "react";
import INext from "../model/INext";

const Next = (props: INext) => {
  const { toggleComponent } = props;
  return (
    <div>
      <div>To jest drugi component</div>
      <button onClick={() => toggleComponent(false)}>Ukryj</button>
    </div>
  );
};

export default Next;
