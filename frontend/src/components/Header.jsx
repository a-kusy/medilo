import { NavLink } from 'react-router-dom';

const Header = () => {
    return(
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
                        <NavLink to="/account">KONTO</NavLink>
                    </li>
                </ul>
            </div>
        </div>
    )
};
export default Header;