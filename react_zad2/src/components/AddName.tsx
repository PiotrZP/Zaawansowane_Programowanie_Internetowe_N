import React, { useState } from "react";
import "./AddName.css";


const AddName = () => {
    const [show, setShow] = useState(false);

    const ShowName = () => {
        setShow((prev) => !prev);

    };

    return (
        <div>
            <p>{show === true ? "Jakub Cisowski" : null}</p>
            <button onClick={() => { ShowName() }}>Add name</button>
        </div>
    )
};

export default AddName;