import { useState, useEffect } from "react";
import { getToken, getUser } from "../../helpers";
import { performRequest } from "../../api/config"
import FullCalendar from '@fullcalendar/react'
import timeGridPlugin from '@fullcalendar/timegrid'
import AddSchedule from './AddSchedule';
import { PiXCircleThin } from "react-icons/pi";

const ScheduleView = () => {
    const [scheduleValidityPeriod, setSchedule] = useState();
    const [doctorId, setDoctorId] = useState('')
    const [events, setEvents] = useState([])
    const token = getToken()
    const user = getUser()

    useEffect(() => {
        const fetchData = async () => {
            const doctor = await getDoctor();
            setDoctorId(doctor.id);

            const scheduleValidityPeriod = await getDoctorSchedule(doctor.id);

            setSchedule(scheduleValidityPeriod)

            if (events.length < 1) {
                if (scheduleValidityPeriod) {
                    scheduleValidityPeriod.forEach(period => {
                        for (let date = new Date(period.startDate); date <= new Date(period.endDate); date.setDate(date.getDate() + 1)) {
                            let dayOfWeekId = date.getDay();

                            const foundSchedules = period.schedules.filter(schedule => schedule.dayOfTheWeekId === dayOfWeekId);

                            if (foundSchedules.length > 0) {
                                const event = foundSchedules.map(schedule => {
                                    const formattedDate = formatDate(new Date(date));
                                    return {
                                        title: schedule.specialization.name,
                                        start: `${formattedDate} ${schedule.startTime}`,
                                        end: `${formattedDate} ${schedule.endTime}`,
                                        allDay: false
                                    };
                                });
                                setEvents(prev => [...prev, ...event]);
                            }
                        }
                    });
                } else {
                    console.error("scheduleValidityPeriod is undefined or has no 'array' property");
                }
            }
        };

        fetchData();

    }, []);

    const getDoctor = async () => {
        const res = await performRequest('Doctors/userId/' + user.id, 'get', token)

        if (res != null && res !== undefined) return res
    }

    const getDoctorSchedule = async (doctorId) => {
        const res = await performRequest('ScheduleValidityPeriod/' + doctorId, 'get', token)

        if (res != null && res !== undefined) return res
        else return []
    }

    function formatDate(date) {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');

        return `${year}-${month}-${day}`;
    }

    const [isFormVisible, setIsFormVisible] = useState(false);

    const handleOpenForm = () => {
        setIsFormVisible(true);
    };

    const handleCloseForm = () => {
        setIsFormVisible(false);
    };

    return (
        <>
            <FullCalendar
                plugins={[timeGridPlugin]}
                initialView="timeGridWeek"
                events={events}
                buttonText={{ today: 'Dzisiaj' }}
                customButtons={{
                    AddSchedule:{
                        text: 'Dodaj grafik',
                        click: handleOpenForm
                    }
                }}
                headerToolbar={{
                    left: 'AddSchedule',
                    center: 'title',
                    right: 'today prev,next'
                }}
                titleFormat={{
                    day: 'numeric',
                    month: '2-digit',
                    year: '2-digit',
                    hour12: false,
                }}
                timeZone='locale'
                locale='pl'
                dayHeaderFormat={{
                    weekday: 'short',
                    day: 'numeric',
                    month: 'short',
                    format: 'DD.MM.YY',
                    omitCommas: true
                }}
                slotMinTime="08:00:00"
                slotMaxTime="19:00:00"
                slotLabelFormat={{
                    hour: 'numeric',
                    minute: '2-digit',
                    hour12: false
                }}
                firstDay={1}
                allDaySlot={false}
                height='auto'
            />
            {isFormVisible && (
                <div className='schedule-form-cont'>
                    <div className='schedule-form flex-cont-col form-content'>
                        <PiXCircleThin onClick={handleCloseForm} className='close-button' size={30} />
                        <AddSchedule />
                    </div>
                </div>)}
        </>
    );
}
export default ScheduleView