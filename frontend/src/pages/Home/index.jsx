import { Link } from 'react-router-dom';
const HomePage = () => {
  return (
    <div className="auth-panel">
      <div className="home-cont-left">
        <p>Medilo to system mający na celu wspomaganie działania placówki medycznej.
          Przeznaczony jest zarówno dla pacjentów jak i pracowników. <br /> <br/>
          Główne zalety systemu:<br />
            - dostęp do dokumentacji medycznej<br />
            - szybkie umawianie wizyt dla pacjentów<br />
            - kontakt między lekarzem a pacjentem<br />
            - zarządzanie wizytami dla lekarza            
          </p>
        <Link to="/account"><button className="button">Przejdź do konta</button></Link>
      </div>
      <div className="home-cont-right">
        <img src='/medilo-logo.png' alt='logo' className='auth-logo'></img><br></br>
        <h1>MEDILO</h1>
      </div>
    </div>
  );
}
export default HomePage;