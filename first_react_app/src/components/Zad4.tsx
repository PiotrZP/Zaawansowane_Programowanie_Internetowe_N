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

const Zad3 = (): JSX.Element => {
  const [activeLink, setActiveLink] = useState<ILink>();

  const clickLink = useCallback(
    (link: ILink) => link === activeLink,
    [activeLink]
  );

  const highlightedLink = useCallback(
    (link: ILink) => {
      setActiveLink(link);
    },
    [setActiveLink]
  );

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

export default Zad3;
