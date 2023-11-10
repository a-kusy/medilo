import { NavLink } from 'react-router-dom';
import { PiIdentificationCardThin, PiCalendarBlankThin,  PiEnvelopeSimpleThin, PiUserGearThin } from 'react-icons/pi';

const size = 80

const Doctor = () =>{
    return (
        <div class="menu menu-doctor">
            <NavLink to="/">
                <div class="menu-item">
                    <p>WIZYTY</p>
                    <PiIdentificationCardThin size={size}/>
                </div>
            </NavLink>
            <NavLink to="/">
                <div class="menu-item">
                    <p>GRAFIK</p>
                    <PiCalendarBlankThin size={size}/>
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
export default Doctor