import { createContext, useContext, useReducer } from 'react';

export const PersonContext = createContext(null);

const initialState = {
    person: null, 
  };
  
  const personReducer = (state, action) => {
    switch (action.type) {
      case 'ADD':
        return { person: action.data };
      default:
        return state;
    }
  };
export const PersonalDataProvider = ({ children }) => {
  const [personalData, setPersonalData] = useReducer(personReducer, initialState);

  return (
    <PersonContext.Provider value={{ personalData, setPersonalData }}>
      {children}
    </PersonContext.Provider>
  );
};

export const usePerson = () => useContext(PersonContext);