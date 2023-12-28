import React, { useState } from 'react';
import Login from '../auth/Login.jsx';
import Registration from '../auth/Registration.jsx';

const AuthForm = () => {
  const [showLogin, setShowLogin] = useState(true);

  const togglePanel = () => {
    setShowLogin((prevState) => !prevState);
  };

  return (
      <div className='auth-panel'>
        {showLogin ? (
          <>
            <Login/>
            <div className='small-side'>
              <img src='/medilo-logo.png' alt='logo' className='auth-logo'></img><br></br>
              <p>Nie masz jeszcze konta?</p>
              <button className="button" onClick={togglePanel}>REJESTRACJA</button>
            </div>
          </>
        ) : (
          <>
            <div className='small-side-reg'>
              <img src='/medilo-logo.png' alt='logo' className='auth-logo'></img><br></br>
               <p>Masz już konto?</p>
              <button className="button" onClick={togglePanel}>LOGOWANIE</button>
            </div>   
            <Registration/>
          </>
        )}
      </div>
  );

}
export default AuthForm;
