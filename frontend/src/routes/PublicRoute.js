import { AuthForm, HomePage, Help, NotFound} from './index';
import { Navigate } from 'react-router-dom';
import Layout from "./Layout";

export default function PublicRoute() {
    return [
      { path: "/", element: <Layout />, children: [
          { path: "/", element: <HomePage/> },
          { path: "/login", element: <AuthForm /> },
          { path: "/help", element: <Help/>},
          { path: "/account", element: <Navigate to='/login' replace/> },
          { path: "*", element: <NotFound/> },
        ],
      },
    ];
  }
  