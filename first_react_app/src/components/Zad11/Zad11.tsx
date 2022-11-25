import React, {FC, createContext, useState, useEffect} from "react";
import { PreviewImage } from "./PreviewImage";
import './styles.scss';

type ContextType = { 
    currentImgUrl: string
}

const contextInitialValue = {
    state: { currentImgUrl: '' },
    setState: (state: ContextType) => {}
};

export const Zad11Context = createContext(contextInitialValue);

export const Zad11: FC<{}> = ({}) => {
    const [state, setState] = useState(contextInitialValue.state);

    useEffect(() => {
        setState({
            ...state,
            currentImgUrl: 'https://images.ctfassets.net/hrltx12pl8hq/3KWcqxPlvmgkpMS5VdjLAk/3cbdd812faf4b8c343b259656d31a0ee/rendered_15.jpg?fit=fill&w=480&h=270'
        })
    }, [null]);

    const handlePreviewChange = (e: React.MouseEvent<HTMLElement>) => {
        setState({
            ...state,
            currentImgUrl: e.currentTarget.getAttribute('src')!
        })
    }

    return (
        <Zad11Context.Provider value={{ state, setState }}>
            <div className="gallery-wrapper-with-preview">
                <div className="grid-miniatures">
                    <img onClick={(e) => handlePreviewChange(e)} src="data:image/jpeg;base64,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" alt="" />
                    <img onClick={(e) => handlePreviewChange(e)} src="https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg" alt="" />
                    <img onClick={(e) => handlePreviewChange(e)} src="https://cdn.pixabay.com/photo/2018/01/12/10/19/fantasy-3077928__480.jpg" alt="" />
                    <img onClick={(e) => handlePreviewChange(e)} src="https://images.ctfassets.net/hrltx12pl8hq/3KWcqxPlvmgkpMS5VdjLAk/3cbdd812faf4b8c343b259656d31a0ee/rendered_15.jpg?fit=fill&w=480&h=270" alt="" />
                    <img onClick={(e) => handlePreviewChange(e)} src="https://thumbs.dreamstime.com/b/environment-earth-day-hands-trees-growing-seedlings-bokeh-green-background-female-hand-holding-tree-nature-field-gra-130247647.jpg" alt="" />
                </div>
                <div className="preview">
                    <PreviewImage/>
                </div>
            </div>
        </Zad11Context.Provider>
    )
}