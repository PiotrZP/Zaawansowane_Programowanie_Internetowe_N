import SecondComponentProps from "./SecondComponentProps";

const SecondComponent = (props: SecondComponentProps): JSX.Element => {
  const { handleButton } = props;
  return (
    <div>
      <span>Czy chesz dalej uczyc się biblioteki React?</span>
      <div>
        <button onClick={() => handleButton(true)}>TAK</button>
        <button onClick={() => handleButton(false)}>NIE</button>
      </div>
    </div>
  );
};

export default SecondComponent;
