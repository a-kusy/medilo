import ClipLoader from 'react-spinners/ClipLoader';

const Loader = () => {
    return(
        <div>
            <ClipLoader loading={true} size={100} color='#8E9E9E'/>
        </div>
    );
}
export default Loader