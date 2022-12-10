interface SecondProps {
  onBtnClick: (boolean: boolean) => void;
}

export const Drugi = ({ onBtnClick }: SecondProps) => {
  return (
    <>
      <p>Czy chesz dalej uczyć się biblioteki React?</p>
      <button onClick={() => onBtnClick(true)}>Tak</button>
      <button onClick={() => onBtnClick(false)}>Nie</button>
    </>
  );
};
