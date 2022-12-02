import React, {FC, useState} from "react";

export interface IImage {
    src: string
}

export interface IImages {
    images: Array<IImage>
}

export const Zad7: FC<IImages> = ({ images }) => {
    const [activeImg, setActiveImg] = useState(0);
    const [error, setError] = useState({
        errorMessage: "",
        show: false
    })
    let gallerySize = images.length

    const handleSlideAction = (e: React.MouseEvent<HTMLButtonElement>, direction: string) => {
        if(direction == 'next'){
            if(activeImg != gallerySize-1){
                setActiveImg(activeImg+1)
                setError({
                    ...error,
                    errorMessage: '',
                    show: false,
                })
            }else{
                setError({
                    ...error,
                    errorMessage: 'Nie można wyświetlić kolejnego obrazu, wyświetlona jest ostatnia grafika.',
                    show: true,
                })
            }
        }
        if(direction == 'prev'){
            if(activeImg != 0){
                setActiveImg(activeImg-1)
                setError({
                    ...error,
                    errorMessage: '',
                    show: false,
                })
            }else{
                setError({
                    ...error,
                    errorMessage: 'Nie można wyświetlić poprzedniego obrazu, wyświetlona jest pierwsza grafika.',
                    show: true,
                })
            }
        }
    }

    return (
        <>
            <div className="gallery-wrapper">
                <button onClick={(e) => handleSlideAction(e,'prev')} className="slide-prev">&larr;</button>
                { images != null &&
                    images.map((img, index) => (
                        <img key={index} className={activeImg == index ? 'active' : 'hidden'} src={img.src}/>
                    ))
                }
                <button onClick={(e) => handleSlideAction(e,'next')} className="slide-next">&rarr;</button>
            </div>
            <div className={`error-wrapper ${error.show ? '' : 'd-none'}`}>
                <p>{error.errorMessage}</p>
            </div>
        </>
    )
}