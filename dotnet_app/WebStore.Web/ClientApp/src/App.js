import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
// import { Counter } from './components/Counter';

import './custom.css'
// import { AddressGrid } from "./components/address/AddressGrid";
// import { AddressAdd } from "./components/address/AddressAdd";
// import { AddressEdit } from "./components/address/AddressEdit";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        {/* <Route path="/address" component={AddressGrid} />
        <Route path="/address/add" component={AddressAdd} />
        <Route path="/address/edit/:id" component={AddressEdit} /> */}

        <Route path="/fetch-data" component={FetchData} />
      </Layout>
    );
  }
}


