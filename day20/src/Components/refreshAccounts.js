import axios from 'axios';

function refreshAccounts() {
    axios.get('/api/accounts').then((response) => {
        return response.data;
    });
}

export { refreshAccounts };