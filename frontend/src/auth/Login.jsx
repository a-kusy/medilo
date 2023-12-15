import Cookies from 'js-cookie'
import { useState } from "react"
import { performRequest } from '../api/config';
import { toast } from 'react-toastify';

const Login = () => {
  const [data, setData] = useState({ email: "", password: "" })

  const handleChange = ({ currentTarget: input }) => {
    setData({ ...data, [input.name]: input.value })
  };

  const handleLogin = async (e) => {
    e.preventDefault()
    try {
      const res = await performRequest('Accounts/login', 'post', data);

      if (res.token == null) {
        toast.warn(res.message)
      }
      else if (res.token != null && res.token !== undefined) {
        Cookies.set('token', res.token, {
          sameSite: 'lax',
          secure: true
        })
        
        window.location = '/account'
      }

    } catch (error) {
      console.log(error)
    }
  }

  return (
    <>
    <form className='login-form' onSubmit={handleLogin}>
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
      /><br></br>
      <button type="submit" className="button-card button">LOGOWANIE</button>
      
    </form>
    </>
  )
};
export default Login;