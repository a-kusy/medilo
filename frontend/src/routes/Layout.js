import { Outlet } from "react-router-dom";
import { Suspense } from 'react';
import Header from '../components/Header.jsx';
import Footer from '../components/Footer.jsx';
import Loader from '../components/Loader.jsx';
import ErrorBoundary from '../components/ErrorBoundary.js';

export default function Layout() {
    return (
        <>
            <ErrorBoundary>
                <Header />
                <main>
                    <Suspense fallback={<Loader />}>
                        <Outlet />
                    </Suspense>
                </main>
                <Footer />
            </ErrorBoundary>
        </>
    );
};