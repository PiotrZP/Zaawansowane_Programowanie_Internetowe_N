interface SecondComponentProps {
    message: string;
  }
  
  const SecondComponent: React.FC<SecondComponentProps> = ({ message }) => {
    return <p>{message}</p>;
  };

  export default SecondComponent