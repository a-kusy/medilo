import { createContext, useContext, useReducer } from 'react';

const AuthContext = createContext(null);

const initialState = {
  user: null, 
};

const authReducer = (state, action) => {
  switch (action.type) {
    case 'LOGIN':
      return { user: action.pdata };
    case 'LOGOUT':
      return { user: null };
    default:
      return state;
  }
};

export const AuthProvider = ({ children }) => {
  const [userData, setUserData] = useReducer(authReducer, initialState);

  return (
    <AuthContext.Provider value={{ userData, setUserData }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
