import { NavLink, useLocation } from 'react-router-dom';
import { PiIdentificationCardThin, PiCalendarBlankThin, PiFilesThin, PiStethoscopeThin, PiEnvelopeSimpleThin, PiUserGearThin } from 'react-icons/pi';
import { ROLES } from '../const/roles.js';
import { getRoles } from '../helpers/index.js';

const Sidebar = () => {
    const size = 40
    const location = useLocation()
    const roles = getRoles()

    const roleLinks = {
        [ROLES.DOCTOR]:
            [
                { id: 'doctor-appointments', icon: <PiIdentificationCardThin size={size} /> },
                { id: 'schedule', icon: <PiCalendarBlankThin size={size} /> },
                { id: 'doctor-notifications', icon: <PiEnvelopeSimpleThin size={size} /> },
                { id: 'doctor-settings', icon: <PiUserGearThin size={size} /> }
            ],
        [ROLES.PATIENT]:
            [
                { id: 'patient-card', icon: <PiIdentificationCardThin size={size} /> },
                { id: 'appointments', icon: <PiCalendarBlankThin size={size} /> },
                { id: 'documents', icon: <PiFilesThin size={size} /> },
                { id: 'doctors', icon: <PiStethoscopeThin size={size} /> },
                { id: 'notifications', icon: <PiEnvelopeSimpleThin size={size} /> },
                { id: 'settings', icon: <PiUserGearThin size={size} /> }
            ]
    }

    const getLinksForRole = (role) => roleLinks[role] || [];
    const topMargin = 140

    return (
        <div className="sidebar">
            {getLinksForRole(roles[0]).map((link) => (
                <NavLink key={link.id} to={`/${link.id}`} style={{ top: `${getLinksForRole(roles[0]).indexOf(link) * 80 + topMargin}px`, backgroundColor: location.pathname.includes(link.id) ? '#8E9E9E' : 'initial' }}>
                    {link.icon}
                </NavLink>
            ))}
        </div>
    )
}
export default Sidebar