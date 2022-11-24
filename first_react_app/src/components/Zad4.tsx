import { useCallback, useState } from "react";
import "./Zad3.css";

interface ILink {
  name: string;
  value: string;
}

const myLinks: ILink[] = [
  {
    name: "Sport.pl",
    value: "http://sport.pl",
  },
  {
    name: "Flashscore.pl",
    value: "http://flashscore.pl",
  },
  {
    name: "Lentex.pl",
    value: "http://lentex.pl",
  },
];

const Zad4 = (): JSX.Element => {
  const [activeLinks, setActiveLinks] = useState<ILink[]>([]);

  const clickLink = useCallback(
    (link: ILink) => activeLinks.some((activeLink) => activeLink === link),
    [activeLinks]
  );

  const highlightedLink = (link: ILink) => {
    const index: number = activeLinks.findIndex((value) => value === link);
    if (index > -1) {
      const newLinks = [...activeLinks];
      newLinks.splice(index, 1);
      setActiveLinks([...newLinks]);
    } else {
      setActiveLinks((activeLinks) => [...activeLinks, link]);
    }
  };

  return (
    <div className="main">
      <div>
        {myLinks.map((link) => (
          <div
            onClick={() => highlightedLink(link)}
            className={clickLink(link) ? "click" : "normal"}
          >
            <a rel="noreferrer" href={link.value} target="_blank">
              <p>{link.value}</p>
            </a>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Zad4;
