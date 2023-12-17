import Cookies from "js-cookie";
import { useState } from "react"
import { performRequest } from '../api/config';
import { useNavigate } from "react-router-dom";
import { hasRole } from "../helpers";
import { ROLES } from "../const/roles";
import { toast } from 'react-toastify';

const PersonalForm = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({
        name: "",
        surname: "",
        phoneNumber: "",
        birthDate: ""
    })
    const [address, setAddress] = useState({
        street: "", 
        city: "",
        postalCode: "",
        houseNumber: "",
        apartmentNumber: ""
    })

    const handleForm = async (e) =>{
        e.preventDefault()
        
        const reqData = {
            person: data,
            address: address
        }

        const res = await performRequest('Persons', 'post', reqData);
        
        if(res != null && res !== undefined){
            Cookies.set('personId', res.id, {
                sameSite: 'lax',
                secure: true
              })

            if(hasRole(ROLES.DOCTOR)) navigate('/doctor-specializations-form')
            if(hasRole(ROLES.PATIENT)) navigate('/patient-card-form')  
        }
        else{
            toast.warn('Nie udało się zapisać danych.')
        } 
    }

    const handleChange = ({ currentTarget: input }) => {
        setData({ ...data, [input.name]: input.value })
      };

      const handleChangeAddress = ({ currentTarget: input }) => {
        setAddress({ ...address, [input.name]: input.value })
      };

    return (
        <div className="auth-panel"> 
            <form onSubmit={handleForm} className="personal-form">
                <div className="flex-cont">
                <div className="flex-1">
                    <input 
                        type="text"
                        placeholder="Imię"
                        name="name"
                        required
                        onChange={handleChange}
                        value={data.name} />
                    <input 
                        type="text" 
                        placeholder="Nazwisko"
                        name="surname"
                        required
                        onChange={handleChange}
                        value={data.surname}/>
                    <input 
                        type="tel" 
                        placeholder="Telefon"
                        name="phoneNumber"
                        required
                        onChange={handleChange}
                        value={data.phone}/>
                    <input 
                        type="date"
                        placeholder="Data urodzenia"
                        name="birthDate"
                        required
                        onChange={handleChange}
                        value={data.birthDate} />
                </div>
                <div className="flex-1">
                    <input 
                        type="text" 
                        placeholder="Ulica"
                        name="street"
                        required
                        onChange={handleChangeAddress}
                        value={address.street}/>
                    <input 
                        type="text" 
                        placeholder="Miasto"
                        name="city"
                        required
                        onChange={handleChangeAddress}
                        value={address.city}/>
                    <input 
                        type="text" 
                        placeholder="Kod pocztowy"
                        name="zipCode"
                        required
                        onChange={handleChangeAddress}
                        value={address.zipCode}/>
                    <div className="input-container">
                    <input 
                        type="number" 
                        placeholder="Numer domu"
                        name="houseNumber"
                        className="input-left"
                        required
                        onChange={handleChangeAddress}
                        value={address.houseNumber}/>
                    <input 
                        type="number" 
                        placeholder="Numer lokalu"
                        name="apartmentNumber"
                        className="input-right"
                        onChange={handleChangeAddress}
                        value={address.apartmentNumber}/>
                        </div>
                </div> 
                </div>
                <button type="submit">ZATWIERDŹ</button>
            </form>
        </div>
    );
}
export default PersonalForm