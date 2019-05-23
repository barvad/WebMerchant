import React, { Component } from 'react';
import './modal.css';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export class AppModal extends Component {
    static displayName = Modal.name;

    constructor(props) {
        super(props);
        this.state = {
            visible: false,
            content: null,
            title: null,
            command: null,
            cmdBtnText: 'OK',
            cancelBtnText: 'Cancel'
        };
       

    }

    toggle() {
        var st = { ...this.state };
        st.visible = !st.visible;
        this.setState(st);
    }

    render() {
        return <div>
            <Modal centered={true} isOpen={this.state.visible} toggle={()=>this.toggle()} className={this.props.className}>
                <ModalHeader toggle={()=>this.toggle()}>   {this.state.title}</ModalHeader>
                       <ModalBody>
                    {this.state.content}
                       </ModalBody>
                       <ModalFooter>
                    <Button color="primary" hidden={!(this.state.cmdBtnText || this.state.command)} onClick={() => {
                        (this.state.command || (() => { }))();
                        this.toggle();
                        
                    }}>{ this.state.cmdBtnText}</Button>{' '}
                    <Button color="secondary" hidden={!(this.state.cancelBtnText)}  onClick={() => this.toggle()}>   {this.state.cancelBtnText}</Button>
                       </ModalFooter>
                   </Modal>
               </div>;
    }
}