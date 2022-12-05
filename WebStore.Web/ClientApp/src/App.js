import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Root';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'
import { Header } from './components/Header';
import { AddressGrid } from './components/Address/AddressGrid';
import { Container } from 'reactstrap';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div>
        <Header/>
        <Container>
          <AddressGrid/>
        </Container>
      </div>

      // <Layout>
      //   <Route exact path='/' component={Home} />
      //   <Route path='/counter' component={Counter} />
      //   <Route path='/fetch-data' component={FetchData} />
      // </Layout>
    );
  }
}
