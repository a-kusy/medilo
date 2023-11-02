import { BiLogoLinkedinSquare, BiLogoGithub } from 'react-icons/bi';


const Footer= () => {
    return(
        <div className='footer'>
            <p className='section-title'>KONTAKT</p>
            <div className='footer-content'>
                <div>
                    <p>Agnieszka Kusy</p>
                    <p>a.kusy@int.pl</p>
                </div>
                <div className='media'>
                    <a href='https://github.com/a-kusy'><BiLogoGithub size={40}/></a>
                    <a href='https://www.linkedin.com/in/a-kusy/'><BiLogoLinkedinSquare size={40}/></a>
                </div>
            </div>
        </div>
    );
}
export default Footer