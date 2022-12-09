import { useState } from "react";


const MainComponent = (): JSX.Element => {
  const [value, setValue] = useState<number>(0);
  const [error, setError] = useState ("");
  const changeValue = (numer: number) => {
    if(value + numer == -1){
      setError("Wyświetlono pirewsze zdjęcie, nie można wyświetlić wcześniejszego");
    } else if (value + numer == 3){
      setError("Wyświetlono ostatnie zdjęcie, nie można wyświetlić następnego");
    } else {
      setValue((value) => value + numer)
      setError("");
    }
  }
  interface photo{
    idPhoto: number;
    link: string;
  }
  const photos: photo[] = [
    {
      idPhoto: 1,
      link: "https://images.pexels.com/photos/2693208/pexels-photo-2693208.png?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    },
    {
      idPhoto: 2,
      link: "https://images.pexels.com/photos/2983296/pexels-photo-2983296.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
    },
    {
      idPhoto: 3,
      link: "https://images.pexels.com/photos/3780104/pexels-photo-3780104.png?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
    },
  ];
  return (
    <div>
      <p>{value}</p>
      <img src={photos[value].link} width="300" height="300"></img>
      <br></br>
      <button onClick={() => changeValue(-1)}>Poprzednie zdjęcie</button>
      <button onClick={() => changeValue(+1)}>Następne zdjęcie</button>
      <p>{error}</p>
    </div>
  );
};

export default MainComponent;