import { useCallback, useState } from "react";

interface Link {
  name: string;
  value: string;
}
const Links: Link[] = [
  {
    name: "Facebook",
    value: "https://www.facebook.com",
  },
  {
    name: "YouTube",
    value: "https://www.youtube.com",
  },
  {
    name: "Spotify",
    value: "https://www.spotify.com",
  },
];
const MainComponent = (): JSX.Element => {
  const [aktywny, setAktywny] = useState("");
  const zmienNaAktywny = (link: Link) => {
    setAktywny(link.name);
  }
  const czyAktywny = (link: Link) => {
    if(aktywny === link.name){
      return true;
    }
    return false;
  }

return (
  <div>
    <div>
      {Links.map((link) => (
        <div onClick={() => zmienNaAktywny(link)} className={czyAktywny(link) ? "wybrany" : "pusty"} >
          <a href={link.value} target="_blank">{link.name}</a>
        </div>
      ))}
    </div>
  </div>
);
};

export default MainComponent;