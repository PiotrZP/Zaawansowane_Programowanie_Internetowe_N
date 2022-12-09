import './App.css';
import Zad7 from './components/Zad7';

const imgs: string[] = [
  "..//img/im0.jpg",
  "..//img/im1.jpg",
  "..//img/im2.jpg",
  "..//img/im3.jpg",
  "..//img/im4.jpg",
];
function App() {
  return (
    <div className="App">
      <Zad7 images={imgs} />
    </div>
  );
}

export default App;
