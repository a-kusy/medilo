import React from 'react';
import ReactDOM from 'react-dom/client';
import './style/index.scss';
import App from './App';
import ErrorBoundary from './components/ErrorBoundary.jsx';
import {ToastContainer } from 'react-toastify';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <ErrorBoundary>
          <App />
          <ToastContainer />
    </ErrorBoundary>
  </React.StrictMode>
);