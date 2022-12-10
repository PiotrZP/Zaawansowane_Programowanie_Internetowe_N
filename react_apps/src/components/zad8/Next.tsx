import INextProps from "../../model/INextProps";

const Next = (props: INextProps) => {
  const { toggleComponent } = props;
  return (
    <div>
      <div>To jest drugi component</div>
      <button onClick={() => toggleComponent(false)}>Ukryj</button>
    </div>
  );
};

export default Next;
