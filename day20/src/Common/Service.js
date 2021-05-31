import React, { Component } from 'react';
import { Button, FormGroup, Input, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table } from 'reactstrap';
import { observer } from "mobx-react";
import { makeObservable, observable, action } from 'mobx';
import axios from 'axios';

const Service = observer(
    class Service extends Component {
        api = 'https://localhost:44317/api/accounts';
        // From old state statement
        accounts = [];
        newAccountData = { details: '', status: '' };
        editAccountData = { accNum: '', details: '', status: '' };
        newAccountModal = false;
        editAccountModal = false;

        constructor() {
            super();

            makeObservable(this, {
                accounts: observable,
                newAccountData: observable,
                editAccountData: observable,
                newAccountModal: observable,
                editAccountModal: observable,
                setEditAccountModal: action,
                setNewAccountModal: action,
                refreshAccounts: action,
                addAccount: action,
                deleteAccount: action,
                updateAccount: action,
                editAccount: action,
                setNewAccountData: action,
                setEditAccountData: action
            });
        }

        componentDidMount() {
            this.refreshAccounts();
        }

        refreshAccounts() {
            axios.get(this.api).then((response) => {
                this.accounts = response.data;
            });
        }

        toggleNewAccountModal = () => {
            this.setNewAccountModal(!this.newAccountModal);
        }

        toggleEditAccountModal = () => {
            this.setEditAccountModal(!this.editAccountModal);
        }

        setNewAccountModal(value) {
            this.newAccountModal = value;
        }
          
        setEditAccountModal(value) {
            this.editAccountModal = value;
        }

        addAccount(data) {
            axios.post('https://localhost:44317/api/accounts', data).then((response) => {
                this.refreshAccounts();
                this.setNewAccountModal(false);
                this.newAccountData = { accNum: '', details: '', status: '' };
            });
        }

        updateAccount() {
            let { details, status } = this.editAccountData;
            axios.put(this.api + this.editAccountData.accNum, { details, status }).then((response) => {
                this.refreshAccounts();
            });
        }

        editAccount(accNum, details, status) {
            this.setEditAccountModal(!this.editAccountModal);
            this.setEditAccountData("details", details);
            this.setEditAccountData("status", status);
            this.setEditAccountData("accNum", accNum);
        }

        setNewAccountData(field, value){
            if (field == "details"){
                this.newAccountData.details = value;
            } else if (field == "status"){
                this.newAccountData.status = value;
            }
        }

        setEditAccountData(field, value){
            if (field == "details"){
                this.editAccountData.details = value;
            } else if (field == "status"){
                this.editAccountData.status = value;
            } else if (field == "accNum"){
                this.editAccountData.accNum = value;
            }
        }

        deleteAccount(accNum) {
            axios.delete(this.api, accNum).then((response) => {
                this.refreshAccounts();
            });
        }

        render() {
            let accounts = this.accounts.map((account) => {
                return (
                    <tr key={account.accNum}>
                        <td>{account.accNum}</td>
                        <td>{account.details}</td>
                        <td>{account.status}</td>
                        <td>
                            <Button color="success" size="sm" className="mr-2" onClick={() => this.editAccount(account.accNum, account.details, account.status)}>Update</Button>
                            <Button color="danger" size="sm" onClick={() => this.deleteAccount(account.accNum)}>Delete</Button>
                        </td>
                    </tr>
                )
            });

            return (
                <>
                    <Button className="my-3" color="primary" onClick={() => this.toggleNewAccountModal()}>Add Account</Button>

                    <Modal isOpen={this.newAccountModal} toggle={() => this.toggleNewAccountModal()}>
                        <ModalHeader toggle={() => this.toggleNewAccountModal()}>Add a new account</ModalHeader>

                        <ModalBody>
                            <FormGroup>
                                <Label for="details">Details</Label>
                                <Input id="details" value={this.newAccountData.details} onChange={(e) => {
                                    this.setNewAccountData("details", e.target.value);
                                }} />
                            </FormGroup>

                            <FormGroup>
                                <Label for="status">Status</Label>
                                <Input id="status" value={this.newAccountData.status} onChange={(e) => {
                                    this.setNewAccountData("status", e.target.value);
                                }} />
                            </FormGroup>
                        </ModalBody>

                        <ModalFooter>
                            <Button color="primary" onClick={() => this.addAccount()}>Add Account</Button>{' '}
                            <Button color="secondary" onClick={() => this.toggleNewAccountModal()}>Cancel</Button>
                        </ModalFooter>
                    </Modal>

                    <Modal isOpen={this.editAccountModal} toggle={() => this.toggleEditAccountModal()}>
                        <ModalHeader toggle={() => this.toggleEditAccountModal()}>Edit account</ModalHeader>
                        <ModalBody>
                            <FormGroup>
                                <Label for="details">Details</Label>
                                <Input id="details" value={this.editAccountData.details} onChange={(e) => {
                                    this.setEditAccountData("details", e.target.value);
                                }} />
                            </FormGroup>

                            <FormGroup>
                                <Label for="status">Status</Label>
                                <Input id="status" value={this.editAccountData.status} onChange={(e) => {
                                    this.setEditAccountData("status", e.target.value);
                                }} />
                            </FormGroup>
                        </ModalBody>

                        <ModalFooter>
                            <Button color="primary" onClick={() =>this.updateAccount()}>Update Account</Button>{' '}
                            <Button color="secondary" onClick={() => this.toggleEditAccountModal()}>Cancel</Button>
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
                </>
            );
        }
    }
);
export default Service;