import ImageBoxProps from "./ImageBoxProps";

const ImageBox = (props: ImageBoxProps): JSX.Element => {
  const { imageUrl } = props;
  return (
    <div>
      <img src={imageUrl} alt={imageUrl} />
    </div>
  );
};

export default ImageBox;
