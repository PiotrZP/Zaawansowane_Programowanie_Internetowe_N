import { useCallback, useState } from "react";
import ILink from "../model/ILink";
import "./Zad3i4.css"

const links: ILink[] = [
  {
    name: "google",
		url: "https://www.google.com"
  },
	{
    name: "onet",
		url: "https://www.onet.pl"
  },
	{
    name: "wp",
		url: "https://www.wp.pl"
  },
];

const Zad3i4 = () => {
	const [pressedLinks, setPressedLinks] = useState<ILink[]>([]);
	const [pressedLink, setPressedLink] = useState<ILink>();
	
	const areLinksPressed = useCallback(
		(link:ILink) => pressedLinks.some((pressedLink)=>pressedLink===link),
		[pressedLinks]
	);

	const isLinkPressed = useCallback(
		(link:ILink) => link === pressedLink,
		[pressedLink]
	);
	
	const addPressedLink = useCallback(
		(link:ILink) => {
			if (!areLinksPressed(link)) {
				setPressedLinks((pressedLinks) => [...pressedLinks, link]);
			}
			setPressedLink(link);
		},
		[areLinksPressed]
	);
	
	return ( 
<div className="container">
      <div>
        {links.map((link) => (
          <div
            key={link.name}
            onClick={() => addPressedLink(link)}
            className={
              areLinksPressed(link) ? "pressed" : "normal"
            }
          >
            <a rel="noopener noreferrer" href={link.url} target="_blank">
              {link.name}
            </a>
          </div>
        ))}
      </div>
      <div>
        {links.map((link) => (
          <div
            key={link.name}
            onClick={() => addPressedLink(link)}
            className={
              isLinkPressed(link) ? "pressed" : "normal"
            }
          >
            <a rel="noopener noreferrer" href={link.url} target="_blank">
              {link.name}
            </a>
          </div>
        ))}
      </div>
    </div>
	);
}

export default Zad3i4;