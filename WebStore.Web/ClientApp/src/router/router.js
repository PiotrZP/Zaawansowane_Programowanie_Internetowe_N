import { createBrowserRouter } from 'react-router-dom';
import { AddressAdd } from '../components/Address/AddressAdd';
import { AddressDelete } from '../components/Address/AddressDelete';
import { AddressEdit } from '../components/Address/AddressEdit';
import { AddressGrid } from '../components/Address/AddressGrid';
import { Home } from '../components/Home';
import { Root } from '../components/Root';

const router = createBrowserRouter([
    {
      element: <Root/>,
      children: [
        {
          index: true,
          path: '/',
          element: <Home/>
        },
        {
          path: '/address',
          element: <AddressGrid/>
        },
        {
          path: 'address/add',
          element: <AddressAdd/>
        },
        {
          path: '/address/edit/:id',
          element: <AddressEdit/>
        },
        {
          path: '/address/delete/:id',
          element: <AddressDelete/>
        }
      ]
    },
])
export default router;