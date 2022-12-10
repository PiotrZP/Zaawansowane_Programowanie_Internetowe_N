import { AddressAdd } from './components/address/AddressAdd';
import { AddressDelete } from './components/address/AddressDelete';
import { AddressEdit } from './components/address/AddressEdit';
import { AddressGrid } from './components/address/AddressGrid';
import { Home } from './components/Home';

const AppRoutes = [
  {
    index: true,
    element: <AddressGrid />,
  },
  {
    path: '/home',
    element: <Home />,
  },
  {
    path: '/address',
    element: <AddressGrid />,
  },
  {
    path: '/address/add',
    element: <AddressAdd />,
  },
  {
    path: '/address/edit/:id',
    element: <AddressEdit />,
  },
  {
    path: '/address/delete/:id',
    element: <AddressDelete />,
  },
];
export default AppRoutes;
