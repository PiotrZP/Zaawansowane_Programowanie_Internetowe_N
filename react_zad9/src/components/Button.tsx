import React, { useState } from "react";
import Notification from "./Notification";
import "./Button.css"

const Button = () => {
    const [show, setShow] = useState(false);

    const handleClick = () => {
        setShow((prev) => !prev);
    };

    return (
        <div>
            {show && <Notification />}
            <button onClick={handleClick}>Button</button>
        </div>
    );
};

export default Button;