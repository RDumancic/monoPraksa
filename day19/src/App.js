import React, { Component } from 'react';
import axios from 'axios';
import { Button, FormGroup, Input, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table } from 'reactstrap';

class App extends Component {
  accountApi = 'https://localhost:44317/api/accounts';
  
  state = {
    accounts: [],
    newAccountData: {
      details: '',
      status: ''
    },
    editAccountData: {
      accNum: '',
      details: '',
      status: ''
    },
    newAccountModal: false,
    editAccountModal: false
  }

  componentWillMount() {
    this._refreshAccounts();
  }

  toggleNewAccountModal() {
    this.setState({
      newAccountModal: !this.state.newAccountModal
    });
  }

  toggleEditAccountModal() {
    this.setState({
      editAccountModal: !this.state.editAccountModal
    });
  }

  addAccount() {
    axios.post(this.accountApi, this.state.newAccountData).then((response) => {
      let { accounts } = this.state;

      accounts.push(response.data);

      this.setState({ accounts, newAccountModal: false, newAccountData: {
        details: '',
        status: ''
      }});
    });
  }

  updateAccount() {
    let { details, status } = this.state.editAccountData;

    axios.put(this.accountApi + this.state.editAccountData.accNum, {
      details, status
    }).then((response) => {
      this._refreshAccounts();

      this.setState({
        editAccountModal: false, editAccountData: { accNum: '', details: '', status: '' }
      })
    });
  }

  editAccount(accNum, details, status) {
    this.setState({
      editAccountData: { accNum, details, status }, 
      editAccountModal: !this.state.editAccountModal
    });
  }

  deleteAccount(accNum) {
    axios.delete(this.accountApi + accNum).then((response) => {
      this._refreshAccounts();
    });
  }

  _refreshAccounts() {
    axios.get(this.accountApi).then((response) => {
      this.setState({
        accounts: response.data
      })
    });
  }

  render() {
    let accounts = this.state.accounts.map((account) => {
      return (
        <tr key={account.accNum}>
          <td>{account.accNum}</td>
          <td>{account.details}</td>
          <td>{account.status}</td>
          <td>
            <Button color="success" size="sm" className="mr-2" onClick={this.editAccount.bind(this, account.accNum, account.details, account.status)}>Update</Button>
            <Button color="danger" size="sm" onClick={this.deleteAccount.bind(this, account.accNum)}>Delete</Button>
          </td>
        </tr>
      )
    });

    return (
      <div className="App container">

      <h1>Accounts App</h1>

      <Button className="my-3" color="primary" onClick={this.toggleNewAccountModal.bind(this)}>Add Account</Button>

      <Modal isOpen={this.state.newAccountModal} toggle={this.toggleNewAccountModal.bind(this)}>
        <ModalHeader toggle={this.toggleNewAccountModal.bind(this)}>Add a new account</ModalHeader>

        <ModalBody>
          <FormGroup>
            <Label for="details">Details</Label>
            <Input id="details" value={this.state.newAccountData.details} onChange={(e) => {
              let { newAccountData } = this.state;

              newAccountData.details = e.target.value;

              this.setState({ newAccountData });
            }} />
          </FormGroup>

          <FormGroup>
            <Label for="status">Status</Label>
            <Input id="status" value={this.state.newAccountData.status} onChange={(e) => {
              let { newAccountData } = this.state;

              newAccountData.status = e.target.value;

              this.setState({ newAccountData });
            }} />
          </FormGroup>
        </ModalBody>

        <ModalFooter>
          <Button color="primary" onClick={this.addAccount.bind(this)}>Add Account</Button>{' '}
          <Button color="secondary" onClick={this.toggleNewAccountModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={this.state.editAccountModal} toggle={this.toggleEditAccountModal.bind(this)}>
        <ModalHeader toggle={this.toggleEditAccountModal.bind(this)}>Edit account</ModalHeader>
        <ModalBody>
          <FormGroup>
            <Label for="details">Details</Label>
            <Input id="details" value={this.state.editAccountData.details} onChange={(e) => {
              let { editAccountData } = this.state;

              editAccountData.details = e.target.value;

              this.setState({ editAccountData });
            }} />
          </FormGroup>

          <FormGroup>
            <Label for="status">Status</Label>
            <Input id="status" value={this.state.editAccountData.status} onChange={(e) => {
              let { editAccountData } = this.state;

              editAccountData.status = e.target.value;

              this.setState({ editAccountData });
            }} />
          </FormGroup>
        </ModalBody>

        <ModalFooter>
          <Button color="primary" onClick={this.updateAccount.bind(this)}>Update Account</Button>{' '}
          <Button color="secondary" onClick={this.toggleEditAccountModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>


        <Table>
          <thead>
            <tr>
              <th>#</th>
              <th>Details</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>

          <tbody>
            {accounts}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default App;