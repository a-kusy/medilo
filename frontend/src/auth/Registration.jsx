const Registration = () => {
    return(
         <form className='registration-form'>
            <input
               type="text"
               placeholder="PESEL"
               id="pesel"
               name="pesel"
               className="input"
               required
             />
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
           <button type="submit" className="button-card button">REJESTRACJA</button>
         </form>
    )
   };
   export default Registration;