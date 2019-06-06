import React, { Component } from 'react';


export class Checkout extends Component {
    static displayName = Checkout.name;

    constructor(props) {
        super(props);
        this.state = { order: { id: localStorage['processingOrder'] } };
        setTimeout(() => this.getData(), 0);
    }


    getData() {
        fetch('api/Order/GetOrder',
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.state.order)
            })
            .then(response => response.status == 200 ? response.json() : { hasErrors:true })
            .then(data => {
                if (data.hasErrors)
                    alert('There were errors when getting the order');
                var state = { ...this.state, ...data };
                this.setState(state);
            });
    }

    renderPaymentStep() {
        return <div><label htmlFor="sumInput">Sum: </label><input id="sumInput" name="sum" type="text" /></div>;

    }

    renderDeliveryInfoStep() {
        return <div></div>;
    }

    render() {
        switch (this.state.order.state) {
            case undefined:
                return <div><h2>You have processing order.</h2><button className="btn btn-primary">Next</button><button className="btn btn-secondary">Cancel</button></div>;
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