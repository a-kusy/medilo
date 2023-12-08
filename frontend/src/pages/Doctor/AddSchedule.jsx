import { useState, useEffect } from "react"
import { performRequest } from "../../api/config"
import { PiPlusCircleLight, PiXCircleThin } from "react-icons/pi"
import { toast } from 'react-toastify';
import { getToken } from "../../helpers";

const AddSchedule = () => {
    const [schedules, setSchedules] = useState([{ startTime: '', endTime: '', dayOfTheWeekId: '', specializationId: '', scheduleValidityPeriodId: '' }])
    const [validityPeriod, setValidityPeriod] = useState({ startDate: '', endDate: '', doctorId: '' })
    const [specializations, setSpecializations] = useState([])
    const [daysOfTheWeek, setDaysOTheWeek] = useState([])
    const token = getToken()

    useEffect(() => {
        const fetchData = async () => {
            const specializations = await getSpecializations()
            const days = await getDaysOfTheWeek()

            setSpecializations(specializations)
            setDaysOTheWeek(days)
        };

        fetchData();
    }, []);

    const getSpecializations = async () => {
        const doctorId = 5

        const res = await performRequest('Doctors/specializations/' + doctorId, 'get')

        if (res != null && res !== undefined) return res
        else return []
    };

    const getDaysOfTheWeek = async () => {
        const res = await performRequest('DaysOfTheWeek')

        if (res != null && res !== undefined) return res
        else return []
    }

    const handleSubmit = async (e) => {
        e.preventDefault()
        validityPeriod.doctorId = 5
        const validityPeriodres = await performRequest('ScheduleValidityPeriod', 'post', validityPeriod, token)

        if (validityPeriodres != null && validityPeriod !== undefined) {
            console.log(validityPeriodres)
            const data = schedules.map(schedule => ({
                ...schedule,
                scheduleValidityPeriodId: validityPeriodres.id
            }));
            console.log(data)
            const res = await performRequest('Schedules', 'post', data, token)

            if (res != null && res !== undefined) {
                toast.success('Grafik został zapisany poprawnie.')
                window.location.reload()
            }
            else toast.warn('Coś poszło nie tak. Sprawdź, czy godziny pracy nie kolidują ze sobą.')
        }
        else {
            toast.warn('Coś poszło nie tak. Sprawdź, czy podane godziny nie kolidują z istniejącym grafikiem.')
        }
    }

    const handleChange = ({ currentTarget: input }) => {
        setValidityPeriod({ ...validityPeriod, [input.name]: input.value })
    };

    const handleChangeSchedule = (index, input) => {
        const newSchedules = [...schedules];
        newSchedules[index] = {
            ...newSchedules[index],
            [input.name]: input.value,
        };
        setSchedules(newSchedules);
    };

    const handleDayChange = (event, index) => {
        const newSchedules = [...schedules];
        newSchedules[index].dayOfTheWeekId = event.target.value;
        setSchedules(newSchedules);
    };

    const handleSpecializationChange = (event, index) => {
        const newSchedules = [...schedules];
        newSchedules[index].specializationId = event.target.value;
        setSchedules(newSchedules);
    }

    const handleAddSchedule = () => {
        setSchedules((prevSchedules) => [...prevSchedules, { startTime: '', endTime: '', dayOfTheWeekId: '', specializationId: '' }])
    }

    const handleRemoveSchedule = (index) => {
        const newSchedules = [...schedules];
        newSchedules.splice(index, 1);
        setSchedules(newSchedules);
    };

    return (
        <form onSubmit={handleSubmit} className='add-schedule-form'>
            DODAWANIE NOWEGO GRAFIKU
            <div className="schedule-validity-period">
                Okres obowiązywania grafiku:
                <input
                    type="date"
                    name="startDate"
                    onChange={handleChange}
                    value={validityPeriod.startDate}
                />
                <input
                    type="date"
                    name="endDate"
                    onChange={handleChange}
                    value={validityPeriod.endDate}
                />
            </div>
            Godziny pracy: <br />
            {schedules.map((schedule, index) => (
                <div key={index}>
                    od:
                    <input
                        type="time"
                        name="startTime"
                        onChange={(e) => handleChangeSchedule(index, e.target)}
                        value={schedule.startTime}
                    />
                    do:
                    <input
                        type="time"
                        name="endTime"
                        onChange={(e) => handleChangeSchedule(index, e.target)}
                        value={schedule.endTime}
                    />
                    <select value={schedule.dayOfTheWeekId} onChange={(e) => handleDayChange(e, index)}>
                        <option value="" disabled>Dzień tygodnia</option>
                        {daysOfTheWeek.map((day) => (
                            <option key={day.id} value={day.id}>
                                {day.name}
                            </option>
                        ))}
                    </select>
                    <select value={schedule.specializationId} onChange={(e) => handleSpecializationChange(e, index)}>
                        <option value="" disabled>Specjalizacja</option>
                        {specializations.map((spec) => (
                            <option key={spec.id} value={spec.id}>
                                {spec.name}
                            </option>
                        ))}
                    </select>
                    <PiXCircleThin onClick={() => handleRemoveSchedule(index)} size={18} className="icon-button" />
                </div>
            ))}
            <div>
            </div>
            <PiPlusCircleLight onClick={handleAddSchedule} size={15} className="icon-button" />Dodaj kolejne godziny pracy <br />

            <button type="submit">ZATWIERDŹ</button>
        </form>
    )
}
export default AddSchedule