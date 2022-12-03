function NewComponent(props: { hide: () => void }) {
  return <div onClick={props.hide}>Nowy komponent</div>;
}

export default NewComponent;
