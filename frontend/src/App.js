import { createBrowserRouter, RouterProvider } from "react-router-dom";
import React from 'react';
import PrivateRoute from './routes/PrivateRoute.js';
import PublicRoute from './routes/PublicRoute.js';
import Cookies from "js-cookie";

function App() {
  const user = Cookies.get('token');

  const router = createBrowserRouter([
    user ? PrivateRoute(user) : {},
    ...PublicRoute(),
  ]);

  return (
    <RouterProvider router={router} />
  );
}
export default App;
