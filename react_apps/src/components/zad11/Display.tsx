import IDisplayProps from "../../model/IDisplayProps";

const Display = (props: IDisplayProps) => {
  const { url } = props;
  return (
    <div>
      <img src={url} alt={url} />
    </div>
  );
};

export default Display;
