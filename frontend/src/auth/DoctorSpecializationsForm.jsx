import React, { useState, useEffect } from 'react';
import { PiPlusCircleLight, PiXCircleThin } from 'react-icons/pi';
import { performRequest } from '../api/config';
import { useNavigate } from "react-router-dom";
import { getUser, getPersonId, getToken } from '../helpers';
import { toast } from 'react-toastify';

const DoctorSpecializationsForm = () => {
    const [specializations, setSpecializations] = useState([]);
    const [selectedSpecializations, setSelectedSpecializations] = useState([{ id: '', name: '' }]);
    const [availableSpecializationsCount, setAvailableSpecializationsCount] = useState(0);
    const [person, setPerson] = useState({})
    const personId = getPersonId();
    const navigate = useNavigate();
    const token = getToken()

    useEffect(() => {
        const fetchData = async () => {
            const person = await getPerson();
            const fetchedSpecialties = await getSpecializations();

            setPerson(person)
            setSpecializations(fetchedSpecialties);
            setAvailableSpecializationsCount(fetchedSpecialties.length)
        };

        fetchData();

    }, []);

    const getSpecializations = async () => {
        const res = await performRequest('Specializations')

        if (res != null && res !== undefined) {
            return res
        }
        else return []
    };

    const getPerson = async () => {
        const res = await performRequest('Persons/' + personId, 'get', token)

        if (res != null && res !== undefined) {
            return res
        }
    }

    const handleSpecialtyChange = (index, selectedSpecialtyId) => {
        const updatedSpecialties = [...selectedSpecializations];
        updatedSpecialties[index] = {
            id: parseInt(selectedSpecialtyId),
            name: specializations.find((spec) => spec.id === parseInt(selectedSpecialtyId))?.name || '',
        };

        setSelectedSpecializations(updatedSpecialties);
    };

    const handleAddSpecialty = () => {
        if (selectedSpecializations.length < availableSpecializationsCount) {
            setSelectedSpecializations((prevSpecialties) => [...prevSpecialties, { id: '', name: '' }]);
        }
    };

    const handleRemoveSpecialty = (index) => {
        const newSpecialty = [...selectedSpecializations];
        selectedSpecializations.splice(index, 1);
        setSelectedSpecializations(newSpecialty);
      };

    const handleSubmit = async (e) => {
        e.preventDefault()

        const data = {
            userId: parseInt(getUser().id, 10),
            personId: personId,
            specializations: selectedSpecializations
        }
        const res = await performRequest('Doctors', 'post', data)

        if (res != null && res !== undefined) {
            toast.success('Konto zostało założone. Czekaj na zaakceptowanie.')
            navigate('/doctor')
        }
        else{
            toast.warn('Coś poszło nie tak')
        }
    };

    return (
        <div className="auth-panel flex-cont-col">
            <div className='patient-card-form-title'>
                <p>{person.name} {person.surname}</p>
            </div>
            <form onSubmit={handleSubmit} className='doctor-specializations-form'>
                Wybierz specjalizacje:
                {selectedSpecializations.map((selectedSpecialty, index) => (
                    <div key={index}>
                        <select
                            value={selectedSpecialty.id}
                            onChange={(e) => handleSpecialtyChange(index, e.target.value)}
                        >
                            <option value="" disabled>
                                Specjalizacja
                            </option>
                            {specializations.map((spec) => (
                                <option key={spec.id} value={spec.id}>
                                    {spec.name}
                                </option>
                            ))}
                        </select>
                        <PiXCircleThin onClick={() => handleRemoveSpecialty(index)} size={18} className="icon-button"/>
                    </div>
                ))}

                <PiPlusCircleLight onClick={handleAddSpecialty} size={18} />Dodaj kolejną specjalizację <br />

                <button type="submit">ZATWIERDŹ</button>
            </form>
        </div>
    )
}
export default DoctorSpecializationsForm