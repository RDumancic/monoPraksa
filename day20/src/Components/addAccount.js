import axios from 'axios';

function addAccount(data) {
    axios.post('/api/accounts', data).then((response) => {
        
    });
}

export { addAccount };