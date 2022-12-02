import React, { useState } from "react";
import "./NameOnClick.css";


const NameOnClick = () => {
    const [show, setShow] = useState(false);

    const ShowName = () => {
        setShow((prev) => !prev);

    };

    return (
        <div>
            <p>{show === true ? "Krzysztof Curran" : null}</p>
            <button onClick={() => { ShowName() }}>Pokaż Imię</button>
        </div>
    )
};

export default NameOnClick;