import React, { ChangeEvent, FC, useState } from "react";

export interface ILink {
    id: number,
    name: string
    url: string
}
export interface ILinks {
    links: Array<ILink>
}


export const Zad3: FC<ILinks> = ({ links }) => {
    const [selected, setSelected] = useState({
        clickedLink: 0
    });
    
    const handleMultipleSelect = (e: React.MouseEvent<HTMLElement>) => {
        if(e.currentTarget.classList.contains('bg-violet')){
            e.currentTarget.classList.remove('bg-violet')
        }else{
            e.currentTarget.classList.add('bg-violet')
        }
    }

    const handleSingleSelect = (e: React.MouseEvent<HTMLElement>, id: number) => {
        setSelected({
            ...selected,
            clickedLink: id
        })
    }

    return (
        <div>
            { links != null &&
                links.map((link) => (
                    <p key={link.id} className={`p-click ${link.id == selected.clickedLink && 'bg-violet'}`} onClick={(e) => handleSingleSelect(e,link.id)}>{`${link.name} - ${link.url}`}</p>
                ))
            }
        </div>
    )
}