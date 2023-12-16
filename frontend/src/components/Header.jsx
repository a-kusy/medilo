import { NavLink } from 'react-router-dom';
import { PiCaretDownLight } from "react-icons/pi";
import { getToken } from '../helpers';
import Cookies from 'js-cookie';

const Header = () => {
    const user = getToken()

    const logout = () => {
        Cookies.remove('token')
        Cookies.remove('personId')
        window.location = '/account'
    };

    return (
        <div className="header">
            <div className="header-title">
                <NavLink to="/">MEDILO</NavLink>
                <img src='/medilo-logo.png' alt='logo' className='logo'></img>
            </div>
            <div>
                <ul>
                    <li>
                        <NavLink to="/help">POMOC</NavLink>
                    </li>
                    <li>
                        {user ? (
                            <div className='header-dropdown'>
                                <NavLink to="/account">KONTO <PiCaretDownLight size={16}/></NavLink>
                                <button onClick={logout}>Wyloguj</button>
                            </div>
                        ) : (
                            <NavLink to="/account">KONTO</NavLink>
                        )}
                    </li>
                </ul>
            </div>
        </div>
    )
};
export default Header;