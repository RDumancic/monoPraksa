import React, { Component } from 'react';
import { Button, FormGroup, Input, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table } from 'reactstrap';
import { observer } from "mobx-react";
import { makeObservable, observable, action } from 'mobx';
import { refreshAccounts } from '../Components/refreshAccounts';
import { addAccount } from '../Components/addAccount';
import { deleteAccount } from '../Components/deleteAccount';
import { updateAccount } from '../Components/updateAccount';

const Service = observer(
    class Service extends Component {
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
                refreshAccounts: action,
                setEditAccountModal: action,
                setNewAccountModal: action,
                addAccount: action,
                deleteAccount: action,
                updateAccount: action
            });
        }

        componentWillMount() {
            this.accounts = refreshAccounts();
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

        handleAdd(){
            addAccount(this.newAccountData);
            this.accounts = refreshAccounts();
            this.setNewAccountModal(false);
            this.newAccountData = {details: '', status: ''}
        }

        handleUpdate() {
            let { details, status } = this.editAccountData;
            updateAccount(this.editAccountData, details, status);
            this.accounts = refreshAccounts();
            this.editAccountData = {accNum: '', details: '', status: ''};
        }

        editAccount(accNum, details, status) {
            this.setEditAccountModal(!this.editAccountModal);
            this.editAccountData = { accNum, details, status };
        }

        handleDelete(accNum){
            deleteAccount(accNum)
            this.accounts = refreshAccounts();
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
                            <Button color="danger" size="sm" onClick={() => this.handleDelete(account.accNum)}>Delete</Button>
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
                                    this.newAccountData.details = e.target.value;
                                }} />
                            </FormGroup>

                            <FormGroup>
                                <Label for="status">Status</Label>
                                <Input id="status" value={this.newAccountData.status} onChange={(e) => {
                                    this.newAccountData.status = e.target.value;
                                }} />
                            </FormGroup>
                        </ModalBody>

                        <ModalFooter>
                            <Button color="primary" onClick={() => this.handleAdd()}>Add Account</Button>{' '}
                            <Button color="secondary" onClick={() => this.toggleNewAccountModal()}>Cancel</Button>
                        </ModalFooter>
                    </Modal>

                    <Modal isOpen={this.editAccountModal} toggle={() => this.toggleEditAccountModal()}>
                        <ModalHeader toggle={() => this.toggleEditAccountModal()}>Edit account</ModalHeader>
                        <ModalBody>
                            <FormGroup>
                                <Label for="details">Details</Label>
                                <Input id="details" value={this.editAccountData.details} onChange={(e) => {
                                    this.editAccountData.details = e.target.value;
                                }} />
                            </FormGroup>

                            <FormGroup>
                                <Label for="status">Status</Label>
                                <Input id="status" value={this.editAccountData.status} onChange={(e) => {
                                    this.editAccountData.status = e.target.value;
                                }} />
                            </FormGroup>
                        </ModalBody>

                        <ModalFooter>
                            <Button color="primary" onClick={() =>this.handleUpdate()}>Update Account</Button>{' '}
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