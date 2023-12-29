export function getGenderFromPesel(pesel) {
    if (/^\d{11}$/.test(pesel)) {

        const lastDigit = pesel[pesel.length - 1];

        const lastDigitNumber = parseInt(lastDigit, 10);

        if (lastDigitNumber % 2 === 0) {
            return 'K';
        } else {
            return 'M';
        }
    } else {
        return 'Błąd: Numer PESEL powinien mieć dokładnie 11 cyfr.';
    }
}