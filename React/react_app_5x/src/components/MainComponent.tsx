import { useMemo, useState } from "react";
import MainComponentProps from "./MainComponentProps";

const MainComponent = (props: MainComponentProps): JSX.Element => {
  const { images } = props;
  const [activeImageUrl, setActiveImageUrl] = useState("");
  const [error, setError] = useState<string>();

  useMemo(() => {
    if (!activeImageUrl && images.length > 0) setActiveImageUrl(images[0]);
  }, [activeImageUrl, images]);

  const imageIndex = useMemo(
    () => images.findIndex((image) => image === activeImageUrl),
    [activeImageUrl, images]
  );

  const goToPreviousImage = () => {
    if (imageIndex === 0) {
      setError("Start albumu");
      return;
    }
    setError(undefined);
    setActiveImageUrl(images[imageIndex - 1]);
  };

  const goToNextImage = () => {
    if (imageIndex === images.length - 1) {
      setError("End albumu");
      return;
    }
    setError(undefined);
    setActiveImageUrl(images[imageIndex + 1]);
  };

  return (
    <div>
      <div>
        {imageIndex + 1}/{images.length}
      </div>
      <div>
        <img src={activeImageUrl} alt={activeImageUrl} />
      </div>
      <div>
        <div>
          <button onClick={() => goToPreviousImage()}>Poprzednie</button>
          <button onClick={() => goToNextImage()}>Następne</button>
        </div>
        <div>
          <span>{error}</span>
        </div>
      </div>
    </div>
  );
};

export default MainComponent;
