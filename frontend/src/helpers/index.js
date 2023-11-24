import { jwtDecode } from "jwt-decode"
import Cookies from 'js-cookie';

export const getToken =() => {
  return Cookies.get('token')
}

export const getPersonId = () => {
  return Cookies.get('personId')
}

export const hasRole = (expectedRole) => {
    return getRoles().includes(expectedRole);
  };

export function getUser () {
  const token = getToken()
  const decodedToken = jwtDecode(token);
  if(decodedToken) return decodedToken
}

export function getRoles () {
  const token = getToken();
  const decodedToken = jwtDecode(token);

  if (decodedToken && decodedToken.role) {
    return decodedToken.role;
  } else {
    console.log('Nie znaleziono roli w tokenie.');
  }
}

export function getRolesFromToken(token){
  const decodedToken = jwtDecode(token);

  if (decodedToken && decodedToken.role) {
    return decodedToken.role;
  } else {
    console.log('Nie znaleziono roli w tokenie.');
  }
}