import React from 'react';
import logo from './logo.svg';
import './App.css';
import IPerson from './model/IPerson';
import { PersonView } from './components/PersonView';
import { ButtonShow } from './components/ButtonShow';

function App() {

  let myName: IPerson ={firstName: "Sebastian", lastName: "Taranek"}


  return (
    <div className="App">
      <ButtonShow person={myName} ></ButtonShow>
    </div>
  );
}

export default App;
