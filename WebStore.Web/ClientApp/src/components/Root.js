import React from 'react';
import { Outlet } from 'react-router-dom';
import { Container } from 'reactstrap';
import { AddressProvider } from '../contexts/AddressContext';
import { Header } from './Header';

export const Root = (props) => {
    return (
      <AddressProvider>
        <div>
          <Header/>
          <Container>
            <Outlet/>
          </Container>
        </div>
      </AddressProvider>
    );
}
