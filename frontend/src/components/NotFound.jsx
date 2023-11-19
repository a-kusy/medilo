import { Link } from 'react-router-dom';

const NotFound = () => {
    return(
        <div className='not-found'>
            <h1>404 - Strona nie znaleziona</h1>
            <p>Nie możemy znaleźć strony, którą próbujesz odwiedzić.</p>
            <Link to="/account"><button className="button">Powrót do konta</button></Link>
        </div>
    );
}
export default NotFound