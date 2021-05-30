import axios from 'axios';

function deleteAccount(accNum) {
    axios.delete('/api/accounts', accNum).then((response) => {
        
    });
}

export { deleteAccount };