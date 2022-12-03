import IDisplay from "../model/IDisplay";

const Display = (props: IDisplay) => {
  const { url } = props;
  return (
    <div>
      <img src={url} alt={url} />
    </div>
  );
};

export default Display;
