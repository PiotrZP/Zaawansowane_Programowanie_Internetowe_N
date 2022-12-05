import 'bootstrap/dist/css/bootstrap.css';
import ReactDOM from 'react-dom';
import router from './router/router';
import { RouterProvider } from 'react-router-dom';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <RouterProvider router={router} />,
  document.getElementById('root')
)

serviceWorkerRegistration.unregister();
reportWebVitals();
