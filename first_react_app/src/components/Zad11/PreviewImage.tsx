import React, {FC, useContext} from "react";
import { Zad11Context } from "./Zad11";

export const PreviewImage: FC<{}> = ({}) => {
    const { state, setState } = useContext(Zad11Context);

    return (
        <div>
            <img className="fluid-img" src={state.currentImgUrl}/>
        </div>
    )
}