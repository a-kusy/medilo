import { Navigate } from "react-router-dom";
import { AuthForm, HomePage, Help} from './index';
import Layout from "./Layout";

export default function PublicRoute() {
    return [
      { path: "/", element: <Layout />, children: [
          { path: "/", element: <HomePage/> },
          { path: "/login", element: <AuthForm /> },
          { path: "/help", element: <Help/>},
          { path: "*", element: <Navigate to="/login" replace /> },
        ],
      },
    ];
  }
  