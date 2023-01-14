interface SecondComponentProps {
  onClick: (response: string) => void;
}

const SecondComponent: React.FC<SecondComponentProps> = ({ onClick }) => {
  return (
    <div>
      <p>Czy chcesz dalej uczyć się biblioteki React?</p>
      <button onClick={() => onClick("Tak")}>Tak</button>
      <button onClick={() => onClick("Nie")}>Nie</button>
    </div>
  );
};
  export default SecondComponent