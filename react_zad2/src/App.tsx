import React from 'react';
import './App.css';
import AddName from './components/AddName';
import NameOnClick from './components/AddName';

function App() {

  return (
    <div className="App">
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed nec augue nec mi pretium blandit posuere et orci. Maecenas condimentum dui id magna fringilla sollicitudin. Nunc consectetur dolor justo, eu sagittis tortor finibus id. Mauris pulvinar dui metus. Cras porta interdum purus, vitae ultricies ex placerat sit amet. Aenean scelerisque auctor ex nec blandit. Maecenas aliquet eros odio. Donec mollis lacinia semper. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae
        <AddName/>
      </p>
    </div>
  );
}

export default App;