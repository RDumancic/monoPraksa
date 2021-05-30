import axios from 'axios';

function updateAccount(editAccountData, details, status) {
    axios.put(this.accountApi + editAccountData.accNum, { details, status }).then((response) => {

    });
}

export { updateAccount };