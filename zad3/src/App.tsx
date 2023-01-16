import React from 'react';
import logo from './logo.svg';
import './App.css';
import { LinkListElement } from './component/LinkListElement';
import ILinkElement from './model/ILinkElement';
import { ListLinks } from './component/ListLinks';

function App() {

  let mylinks: Array<ILinkElement> =[
    {
      id: 1,
      siteAddress: "https://www.google.pl/",
      describtion: "Fajna wyszukiwarka",
      title: "Google",
      color: "pink"
    },
    {
      id: 2,
      siteAddress: "https://www.youtube.com/",
      describtion: "Super filmy i super kanały",
      title: "YouTube",
      color: "blue"
    }
    ]


  return (
    <div className="App">
      <ListLinks links={mylinks}></ListLinks>
    </div>
  );
}

export default App;
