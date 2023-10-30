const Login = () => {
 return(
      <form className='login-form'>
          <input
            type="email"
            placeholder="Email"
            id="email"
            name="email"
            className="input"
            required
          />
          <input
            type="password"
            placeholder="Hasło"
            id="password"
            name="password"
            className="input"
            required
          /><br></br>
        <button type="submit" className="button-card button">LOGOWANIE</button>
      </form>
 )
};
export default Login;