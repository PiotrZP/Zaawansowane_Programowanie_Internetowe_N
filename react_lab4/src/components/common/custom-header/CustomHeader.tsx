import CustomHeaderProps from "./CustomHeaderProps";
import "./CustomHeader.css";

const CustomHeader = (props: CustomHeaderProps) => {
  return (
    <div>
      <h1 className="header">{props.title}</h1>
    </div>
  );
};

export default CustomHeader;
