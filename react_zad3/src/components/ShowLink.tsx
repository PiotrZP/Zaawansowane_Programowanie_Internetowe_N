import React, { FC, useState, useRef } from "react";
import "./ShowLink.css";

interface ItemProps {
    label: string;
    link: string;
}

const Item: FC<ItemProps> = ({ label, link }) => {
    const [color, setColor] = useState(false);

    const handleOnClick = () => {
        setColor((prev) => !prev);
    };

    return (
        <>
            <a
                className={`${color === true ? "container-link visited" : "container-link"
                    }`}
                href={link}
                target="blank"
                onClick={handleOnClick}
            >
                {label}
            </a>
        </>
    );
};

const ShowLink = () => {
    const links = [
        {
            label: "Dribbble",
            link: "https://dribbble.com",
        },
        {
            label: "Behance",
            link: "https://www.behance.net",
        },
        {
            label: "Awwwards",
            link: "https://www.awwwards.com",
        },
    ];

    return (
        <div className="container">
            {links.map((item) => (
                <Item label={item.label} link={item.link} />
            ))}
        </div>
    );
};

export default ShowLink;