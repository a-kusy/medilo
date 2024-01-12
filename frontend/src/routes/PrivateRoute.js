import { Navigate } from 'react-router-dom';
import Layout from './Layout.js';
import { PersonalForm, PatientCardForm, DoctorSpecializationsForm, Patient, Doctor, Schedule } from './index.js';
import { ROLES } from '../const/roles';
import { getRolesFromToken } from '../helpers/index.js';

export default function PrivateRoute(user) {
  const userRoles = getRolesFromToken(user);

  const renderRoutes = () => {
    const isPatient = userRoles.includes(ROLES.PATIENT)
    const isDoctor = userRoles.includes(ROLES.DOCTOR)

    return [
      { path: '/personal-form', element: <PersonalForm /> },
      { path: '/patient-card-form', element: isPatient? <PatientCardForm /> : <Navigate to='*' replace /> },
      { path: '/doctor-specializations-form',  element: isDoctor? <DoctorSpecializationsForm /> : <Navigate to='*' replace/> },
      { path: '/patient', element: isPatient ? <Patient /> : <Navigate to='*' replace /> },
      { path: '/doctor', element: isDoctor ? <Doctor /> : <Navigate to='*' replace /> },
      { path: "/schedule", element: isDoctor ? <Schedule/> : <Navigate to='*' replace /> },
      { path: '/account', element: (<Navigate to={isPatient ? '/patient' : isDoctor ? '/doctor' : '/login'} replace />) },
      { path: "/login", element: <Navigate to='/account' replace />}
    ]
  }

  return {
    element: <Layout />,
    children: renderRoutes(),
  };
}
