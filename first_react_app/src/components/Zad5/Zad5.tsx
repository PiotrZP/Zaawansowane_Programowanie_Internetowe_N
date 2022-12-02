import React, {FC, useState} from "react";

export const Zad5: FC<{}> = () => {
    const [count, setCount] = useState<number>(0);
    
    const handleCounterUpdate = (e: React.MouseEvent<HTMLElement>, type: string, value: number) => {
        switch(type){
            case 'decrease':
                setCount((prev) => prev - value)
                break;
            case 'increase':
                setCount((prev) => prev + value)
                break;
        }
    }

    return(
        <div className="counter-wrapper">
            <button onClick={(e) => handleCounterUpdate(e,'decrease',1)} type="button">
                <span className="indicator">-</span>
            </button>
            <button onClick={(e) => handleCounterUpdate(e,'decrease',2)} type="button">
                <span className="indicator">-2</span>
            </button>
            <p>{count}</p>
            <button type="button">
                <span onClick={(e) => handleCounterUpdate(e,'increase',1)} className="indicator">+</span>
            </button>
            <button type="button">
                <span onClick={(e) => handleCounterUpdate(e,'increase',2)} className="indicator">+2</span>
            </button>
        </div>
    )
}