import React from 'react';
import { Outlet } from 'react-router-dom';
import { Container } from 'reactstrap';
import { AddressGrid } from './Address/AddressGrid';
import { Header } from './Header';

export const Root = (props) => {
    return (
      <div>
        <Header/>
        <Container>
          <Outlet/>
        </Container>
      </div>
    );
}
