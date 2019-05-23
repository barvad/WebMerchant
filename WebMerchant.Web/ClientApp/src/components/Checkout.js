import React, { Component } from 'react';


export class Checkout extends Component {
    static displayName = Checkout.name;

    constructor(props) {
        super(props);
        this.state = { order: { state: '', id: localStorage['processingOrder'] } };
       
    }


    getData() {
        fetch('api/Order/GetData',
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.state.order)
                })
            .then(response => response.json())
            .then(data => {
                var state = { ...this.state, ...data };
                this.setState(state);
            });
    }

    renderPaymentStep() {
        return <div><label htmlFor="sumInput">Sum:</label><input id="sumInput" name="sum" type="text" /></div>;

    }

    renderDeliveryInfoStep() {
        return <div></div>;
    }

    render() {
        switch (this.state.orderState) {
            case '':
                return <div></div>;
            case 'PurchaseStarted':
                return this.renderPaymentStep();
        case 'paid':
                return this.renderDeliveryInfoStep();
            case 'paymentPostponed':
                return this.renderDeliveryInfoStep(); 
            default:
                throw 'Error order state';
        }
    }
}