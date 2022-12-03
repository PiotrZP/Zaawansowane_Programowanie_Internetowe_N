function NewComponent(props: { showResponse: (response: string) => void }) {
  return (
    <div>
      <h3>Czy chcesz dalej uczyć się biblioteki React?</h3>
      <button onClick={() => props.showResponse('Cieszę się! Idźmy dalej')}>Tak</button>
      <button onClick={() => props.showResponse('Przykro mi, że się męczysz')}>Nie</button>
    </div>
  );
}

export default NewComponent;



