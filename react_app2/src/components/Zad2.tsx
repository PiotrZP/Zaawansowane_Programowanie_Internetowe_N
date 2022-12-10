import { useState } from "react";

const Zad2 = () => {
  const [name, setName] = useState("");
  return ( 
    <div>
      <p>{name}</p>
      <button onClick={()=>setName("Damian Siewiera")}>Autor</button>
    </div>
  );
}

export default Zad2;