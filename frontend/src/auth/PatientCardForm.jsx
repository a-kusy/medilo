import { useState, useEffect } from 'react'
import { getGenderFromPesel } from '../helpers/Validator'
import { performRequest } from '../api/config'
import { getUser, getToken, getPersonId } from '../helpers'
import { useNavigate } from 'react-router'
import { toast } from 'react-toastify';

const PatientCardForm = () => {
    const token = getToken()
    const personId = getPersonId()
    const [person, setPerson] = useState({})
    const navigate = useNavigate

    const [data, setData] = useState({
        sex: '',
        pesel: '',
        personId: personId,
        processingOfPersonalData: false,
        attendingPhysician: "",
        medicalInsurance: ""
    })

    useEffect(() => {
        const fetchData = async () => {
            const p = await performRequest('Persons/' + personId, 'get', token)
            setPerson(p)

            const decodedToken = getUser()
            const user = await performRequest('Users/' + decodedToken.id, 'get', token); 

            data.pesel = user.pesel
            data.sex = getGenderFromPesel(user.pesel)
        }

        fetchData()
    }, []);

    const handleChange = ({ currentTarget: input }) => {
        let value = input.value

        if (input.name === 'processingOfPersonalData') {
            value = input.checked;
          }

        setData({ ...data, [input.name]: value })
    };

    const handleForm = async (e) => {
        e.preventDefault()

        data.processingOfPersonalData = e.target.checked;

        const res = await performRequest('PatientCards', 'post', data);

        if (res != null && res !== undefined) {
            toast.success('Karta założona poprawnie')
            navigate('/patient')
        }
        else{
            toast.warn('Nie udało się założyć karty.')
        }
    }

    return (
        <div className="auth-panel flex-cont-col">
            <div className='patient-card-form-title'>
                <p>{person.name}  {person.surname}</p>
            </div>
            <form className='patient-card-form' onSubmit={handleForm}>
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