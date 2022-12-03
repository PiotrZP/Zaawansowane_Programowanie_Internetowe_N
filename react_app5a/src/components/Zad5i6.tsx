import { useCallback, useState } from "react";

const Zad5i6 = () => {
  const [result, setResult] = useState<number>(0);

  const add = useCallback(
    (num: number) => setResult((result)=> result + num),
    []
  )
  return ( 
    <div>
      <p>{result}</p>
      <button onClickCapture={()=>add(+2)}>+2</button>
      <button onClickCapture={()=>add(+1)}>+1</button>
      <button onClickCapture={()=>add(-1)}>-1</button>
      <button onClickCapture={()=>add(-2)}>-2</button>
    </div>
  );
}

export default Zad5i6;