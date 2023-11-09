import { useState } from 'react'
import { useAuth } from '../context/AuthContext'
import { usePerson } from '../context/PersonContext'
import { getGenderFromPesel } from '../helpers/Validator'

const PatientCardForm = () => {
    const { user } = useAuth()
    const { personalData } = usePerson()
    const u = user.user
    const p = personalData.person

    const gender = getGenderFromPesel(u.pesel)

    const [data, setData] = useState({
        sex: gender,
        pesel: u.pesel,
        personId: 1,
        processingOfPersonalData: false,
        attendingPhysician: "",
        medicalInsurance: ""
    })

    const handleChange = ({ currentTarget: input }) => {
        setData({ ...data, [input.name]: input.value })
    };

    return (
        <div className="auth-panel flex-cont-col">
            <div className='patient-card-form-title'>
                <p>{p.name}  {p.surname}</p>
            </div>
            <form className='patient-card-form'>
                <input
                    type="text"
                    name='attendingPhysician'
                    placeholder='Lekarz prowadzący'
                    onChange={handleChange}
                    value={data.attendingPhysician}
                />
                <input
                    type="text"
                    name='medicalInsurance'
                    placeholder='Ubezpieczenie'
                    onChange={handleChange}
                    value={data.medicalInsurance}
                />
                <div className='checkbox'>
                    <input
                        type="checkbox"
                        name='processingOfPersonalData'
                        required
                        onChange={handleChange}
                    />
                    <p>Wyrażam zgodę na przetwarzanie moich danych osobowych w zakresie określonym przez administratora systemu Medilo.
                        Zgoda obejmuje przetwarzanie następujących danych osobowych: imię i nazwisko, numer PESEL, adres e-mail, numer telefonu, datę urodzenia, adres zamieszkania.
                        Informuję, że mam prawo do cofnięcia tej zgody w dowolnym momencie. Cofnięcie zgody nie wpłynie na legalność przetwarzania danych osobowych dokonanego przed jej cofnięciem.
                    </p>
                </div>
                <button type='submit'>ZATWIERDŹ</button>
            </form>
        </div>
    );
}
export default PatientCardForm