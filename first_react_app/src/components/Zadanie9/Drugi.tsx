interface SecondProps {
  onBtnClick: () => void;
}

export const Drugi = ({ onBtnClick }: SecondProps) => {
  return (
    <>
      <p>Komunikat drugiego komponentu</p>
      <button onClick={onBtnClick}>Ukryj drugi komponent</button>
    </>
  );
};
