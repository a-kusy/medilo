import { lazy } from "react";

export const HomePage = lazy(() => import('../pages/Home'));
export const Help = lazy(() => import('../pages/Help'));
export const AuthForm = lazy(() => import('../pages/AuthForm.jsx'));
export const PersonalForm = lazy(() => import('../auth/PersonalForm.jsx'));
export const PatientCardForm = lazy(() => import('../auth/PatientCardForm.jsx'));
export const Patient = lazy(() => import('../pages/Patient/index.jsx'));
export const Doctor = lazy(() => import('../pages/Doctor/index.jsx'));
export const DoctorSpecializationsForm = lazy(() => import('../auth/DoctorSpecializationsForm.jsx'));