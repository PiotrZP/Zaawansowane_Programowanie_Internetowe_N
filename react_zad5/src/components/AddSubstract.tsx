import React, { useState } from "react";
import "./AddSubstract.css";

const AddSubstract = () => {
    const [number, setNumber] = useState(0);

    const handleClick = (value: number) => {
        setNumber((prev) => (prev += value));
    };

    return (
        <div className="container">
            <button onClick={() => { handleClick(-1); }}>
                -1
            </button>
            <p>{number}</p>
            <button onClick={() => { handleClick(1); }}>
                +1
            </button>
        </div>
    );
};

export default AddSubstract;