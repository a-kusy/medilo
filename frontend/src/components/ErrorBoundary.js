import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class ErrorBoundary extends Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false };
  }

  static getDerivedStateFromError(error) {
    return { hasError: true };
  }

  componentDidCatch(error, errorInfo) {
    
    console.error('Error:', error);
    console.error('Error Info:', errorInfo);
  }

  render() {
    if (this.state.hasError) {
      return (
        <div className='error-page'>
          <h2>Coś poszło nie tak...</h2>
          <p>Kliknij poniżej, aby wrócić na stronę główną:</p>
          <Link to="/">Przejdź do strony głównej</Link>
        </div>
      );
    }

    return this.props.children;
  }
}

export default ErrorBoundary;
