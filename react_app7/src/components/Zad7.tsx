import { useMemo, useState } from "react";
import IZad7 from "../model/IZad7";

const Zad7 = (props: IZad7) => {
  const {images} = props;
  const [imageUrl, setImageUrl] = useState("");
  const [error, setError] = useState<string>();

  useMemo(()=>{
      if (!imageUrl&&images.length>0) setImageUrl(images[0]);
    }, [imageUrl,images] );

  const index = useMemo(
    () => images.findIndex((image) => image === imageUrl),
    [imageUrl, images]
  );
  const prevImage = () => {
    if (index === 0) {
      setError("Początek albumu");
      return;
    }
    setError(undefined);
    setImageUrl(images[index - 1]);
  };

  const nextImage = () => {
    if (index === images.length - 1) {
      setError("Koniec albumu");
      return;
    }
    setError(undefined);
    setImageUrl(images[index + 1]);
  };

  return ( 
    <div>
      <div>
        {index + 1}/{images.length}
      </div>
      <div>
        <img src={imageUrl} alt={imageUrl} />
      </div>
      <div>
        <div>
          <button onClick={() => prevImage()}>Poprzednie</button>
          <button onClick={() => nextImage()}>Następne</button>
        </div>
        <div>
          <span>{error}</span>
        </div>
      </div>
    </div>
  );
}

export default Zad7;