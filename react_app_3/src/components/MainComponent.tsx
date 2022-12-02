import { useCallback, useState } from "react";
import "./MainComponent.css";

interface ILink {
  name: string;
  value: string;
}

const myLinks: ILink[] = [
  {
    name: "Google",
    value: "https://www.google.pl",
  },
  {
    name: "Wp",
    value: "https://www.wp.pl",
  },
  {
    name: "Onet",
    value: "https://www.onet.pl",
  },
];

const MainComponent = (): JSX.Element => {
  const [activeLinks, setActiveLinks] = useState<ILink[]>([]);
  const [activeLink, setActiveLink] = useState<ILink>();

  const isLinkActiveMultiple = useCallback(
    (link: ILink) => activeLinks.some((activeLink) => activeLink === link),
    [activeLinks]
  );

  const isLinkActiveSingle = useCallback(
    (link: ILink) => link === activeLink,
    [activeLink]
  );

  const addActiveLink = useCallback(
    (link: ILink) => {
      if (!isLinkActiveMultiple(link)) {
        setActiveLinks((activeLinks) => [...activeLinks, link]);
      }
      setActiveLink(link);
    },
    [isLinkActiveMultiple]
  );

  console.log(activeLinks);

  return (
    <div className="mc-main-container">
      <div>
        {myLinks.map((link) => (
          <div
            key={link.name}
            onClick={() => addActiveLink(link)}
            className={
              isLinkActiveMultiple(link) ? "mc-link-active" : "mc-link-normal"
            }
          >
            <a rel="noopener noreferrer" href={link.value} target="_blank">
              {link.name}
            </a>
          </div>
        ))}
      </div>
      <div>
        {myLinks.map((link) => (
          <div
            key={link.name}
            onClick={() => addActiveLink(link)}
            className={
              isLinkActiveSingle(link) ? "mc-link-active" : "mc-link-normal"
            }
          >
            <a rel="noopener noreferrer" href={link.value} target="_blank">
              {link.name}
            </a>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MainComponent;
