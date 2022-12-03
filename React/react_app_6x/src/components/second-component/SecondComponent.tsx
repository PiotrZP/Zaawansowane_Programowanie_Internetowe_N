import { SecondComponentProps } from "./SecondComponentProps";

const SecondComponent = (props: SecondComponentProps): JSX.Element => {
  const { toggleComponent } = props;
  return (
    <div>
      <div>Second Container</div>
      <button onClick={() => toggleComponent(false)}>HIDE</button>
    </div>
  );
};

export default SecondComponent;
