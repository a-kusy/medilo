import PropagateLoader from 'react-spinners/PropagateLoader';

const Loader = () => {
    return(
        <div>
            <PropagateLoader loading={true} size={150} color='#8E9E9E'/>
        </div>
    );
}
export default Loader