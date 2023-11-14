import React, { useState, useEffect } from 'react';
import { PiPlusCircleLight } from 'react-icons/pi';
import { performRequest } from '../api/config';
import { useNavigate } from "react-router-dom";
import { usePerson } from '../context/PersonContext'
import { getUser } from '../helpers';

const DoctorSpecializationsForm = () => {
    const [specializations, setSpecializations] = useState([]);
    const [selectedSpecializations, setSelectedSpecializations] = useState([{ id: '', name: '' }]);
    const [availableSpecializationsCount, setAvailableSpecializationsCount] = useState(0);
    const navigate = useNavigate();
    const { personalData } = usePerson()

    useEffect(() => {
        const fetchData = async () => {
            const fetchedSpecialties = await getSpecializations();

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

    const handleSubmit = async (e) => {
        e.preventDefault()

        const data = {
            userId: parseInt(getUser().id, 10),
            personId: personalData.person.id,
            specializations: selectedSpecializations
        }
        const res = await performRequest('Doctors', 'post', data)

        if (res != null && res !== undefined) {
            navigate('/doctor')
        }
    };

    return (
        <div className="auth-panel flex-cont-col">
            <div className='patient-card-form-title'>
                <p>{personalData.person.name} {personalData.person.surname}</p>
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
                    </div>
                ))}

                <PiPlusCircleLight onClick={handleAddSpecialty} size={18} />Dodaj kolejną specjalizację <br />

                <button type="submit">ZATWIERDŹ</button>
            </form>
        </div>
    )
}
export default DoctorSpecializationsForm