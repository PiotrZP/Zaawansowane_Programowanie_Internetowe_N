import React, { FC, useState } from "react"

export const Zad2: FC<{}> = () => {
    const [show, setShow] = useState<boolean>(false);

    const handleShowChange = (e: React.MouseEvent<HTMLButtonElement>) => {
        setShow(!show);
    }

    return (
        <div>
            <p>paragraf</p>
            <button onClick={handleShowChange}>Pokaż imię i nazwisko</button>
            <p style={{ display: show ? 'block' : 'none' }}>Krzysztof Curran</p>
        </div>
    )
}