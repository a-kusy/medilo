import { NavLink } from 'react-router-dom';
import { PiIdentificationCardThin, PiCalendarBlankThin, PiFilesThin, PiStethoscopeThin, PiEnvelopeSimpleThin, PiUserGearThin } from 'react-icons/pi';

const size = 80

const Patient = () => {
    return(       
        <div class="menu">
            <NavLink to="/">
                <div class="menu-item">
                    <p>KARTA PACJENTA</p>
                    <PiIdentificationCardThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div class="menu-item">
                    <p>WIZYTY</p>
                    <PiCalendarBlankThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div class="menu-item">
                    <p>DOKUMENTY</p>
                    <PiFilesThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div class="menu-item">
                    <p>LEKARZE</p>
                    <PiStethoscopeThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div className="menu-item">
                    <p>POWIADOMIENIA</p>
                    <PiEnvelopeSimpleThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div className="menu-item">
                    <p>USTAWIENIA</p>
                    <PiUserGearThin size={size}/>
                </div>
            </NavLink>
        </div>
    );
}
export default Patient