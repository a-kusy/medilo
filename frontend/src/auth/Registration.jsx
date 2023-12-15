import Cookies from 'js-cookie';
import { useState } from "react"
import { performRequest } from '../api/config';
import { ROLES } from '../const/roles.js';
import { toast } from 'react-toastify';

const Registration = () => {
  const [data, setData] = useState({ pesel: "", email: "", password: "", role: ROLES.PATIENT })

  const handleChange = ({ currentTarget: input }) => {
    setData({ ...data, [input.name]: input.value })
  };

  const handleRegister = async (e) => {
    e.preventDefault();

    const user = await performRequest('Accounts/register', 'post', data);

    if (user.token == null) {
      toast.warn(user.message)
    }
    else if (user.token != null && user.token !== undefined) {

      Cookies.set('token', user.token, {
        sameSite: 'lax',
        secure: true
      })

      window.location = "/personal-form"
    }
  }

  return (
    <form className='registration-form' onSubmit={handleRegister}>
      <input
        type="text"
        placeholder="PESEL"
        name="pesel"
        className="input"
        required
        onChange={handleChange}
        value={data.pesel}
      />
      <input
        type="email"
        placeholder="Email"
        name="email"
        className="input"
        required
        onChange={handleChange}
        value={data.email}
      />
      <input
        type="password"
        placeholder="Hasło"
        name="password"
        className="input"
        required
        onChange={handleChange}
        value={data.password}
      />
      <br></br>
      <label className="radio-auth">
        <br />
        <input
          type="radio"
          name="role"
          className="radio-button"
          value={ROLES.PATIENT}
          onChange={handleChange}
          checked={data.role === ROLES.PATIENT}
        /> Pacjent
        <span className="checkmark"></span>
      </label>
      <input
        type="radio"
        name="role"
        className="radio-button"
        value={ROLES.DOCTOR}
        onChange={handleChange}
        checked={data.role === ROLES.DOCTOR}
      /> Lekarz
      <label>
        <input
          type="radio"
          name="role"
          className="radio-button"
          value={ROLES.RECEPTIONIST}
          onChange={handleChange}
          checked={data.role === ROLES.RECEPTIONIST}
        /> Rejestracja
      </label>
      <br></br>
      <button type="submit" className="button-card button">REJESTRACJA</button>
    </form>
  )
};
export default Registration;