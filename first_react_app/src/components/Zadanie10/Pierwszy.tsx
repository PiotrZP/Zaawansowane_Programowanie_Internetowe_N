interface FirstProps {
  onBtnClick: () => void;
}

export const Pierwszy = ({ onBtnClick }: FirstProps) => {
  return <button onClick={onBtnClick}>Pokaz drugi komponent</button>;
};
