import React, { Component } from 'react';
import './Cart.css';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { AppModal } from './AppModal.js';


export class Cart extends AppModal {
    static displayName = Cart.name;

    constructor(props) {
        super(props);
        var cartLines = JSON.parse(localStorage['cartLines'] || '[]');
        this.state = {
            visible: this.props.visible === undefined ? true : this.props.visible,
            content: cartLines.length ? this.getContent() : (<div>Cart is empty</div>),
            title: 'Cart',
            command: cartLines.length ?  ()=>this.startPurchaseOrder(): null,
            cmdBtnText: cartLines.length ?  'Purchase': null,
            cancelBtnText: 'Close'
        };
        window.addToCart = good => { this.addToStorage(good); }
        window.showCart = () => this.setState({ ...this.state, visible: true });
        setTimeout(()=>this.init(),0);
    }

    startPurchaseOrder() {
        fetch('api/Order/Purchase',
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: localStorage['cartLines']
                })
            .then(response => response.ok ? response.json() : { hasError: true }).then(data => {
                if (data.result === 0) {
                    localStorage.removeItem('cartLines');
                    localStorage['processingOrder'] = data.orderId;
                    this.init();
                }
            });
    }

    getContent() {
        var divStyle = { display: 'block !important' };
        var cartLines = JSON.parse(localStorage['cartLines'] || '[]');
        return <table width="100%">{cartLines.map((x,i) => <tr style={({ borderTop:i? '1px solid lightgrey':null, marginBottom: '10px' })}>{Object.values({
            img: <td style={({ padding: '10px' })} ><img src={'/Images/' + x.good.id + '.jpg'} width="70px" height="70px" onError={(e) => { e.target.onerror = null; e.target.src = '/Images/no_foto.jpg' }} /></td>,
            description: <td> {x.good.description}</td>,
            count: <td style={({ paddingLeft: '20px' })}><span onClick={() => this.delFromStorage(x.good)}><img style={({ cursor: 'pointer', width: '15px', height: '15px' })} src="/Static/Images/minus.png" /></span> {x.count}<span onClick={() => this.addToStorage(x.good)}><img style={({ cursor: 'pointer', width: '15px', height: '15px', marginLeft:'5px' })}  src="/Static/Images/plus.png" /></span> </td>
        })}</tr>)}</table>;
    }

  

    addToStorage(good) {
        this.checkOrderState();
        var cartLines = JSON.parse(localStorage['cartLines'] || '[]');
        var line = cartLines.find(l => l.good.id === good.id);
        console.log(line);
        if (line) line.count++;
        else cartLines.push({ good: good, count: 1 });
        localStorage['cartLines'] = JSON.stringify(cartLines);
        this.init();
    }

    delFromStorage(good) {
        var cartLines = JSON.parse(localStorage['cartLines'] || '[]');
        var line = cartLines.find(l => l.good.id === good.id);
        if (line) {
            line.count--;
            if (line.count < 1) {
                cartLines=cartLines.filter((val)=>val!==line);
               
            }
        }
        localStorage['cartLines'] = JSON.stringify(cartLines);
        this.init();
    }

    checkOrderState() {
        if (window.location.pathname != '/checkout' && localStorage['processingOrder'] && localStorage['processingOrder'].length)
            window.location.pathname = '/checkout';
    }

    init() {

        var cartLines = JSON.parse(localStorage['cartLines'] || '[]');
        this.setState({
            ...this.state,
            content: (cartLines.length ? this.getContent() : (<div>Cart is empty</div>)),
            command: cartLines.length ? () => this.startPurchaseOrder() : null,
            cmdBtnText: cartLines.length ? 'Purchase' : null
        });
        var totalCount = 0;
        cartLines.map(x => totalCount += x.count);
        console.log('totalCount',totalCount);
        window.setCartCount && window.setCartCount(totalCount);
        this.checkOrderState();
    }


}