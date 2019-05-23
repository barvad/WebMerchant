import React, { Component } from 'react';
import './CartIcon.css';
import { Cart} from './Cart.js';


export class CartIcon extends Component {
    static displayName = CartIcon.name;

    constructor(props) {
        super(props);
        this.state = { goodsCount: null, chShCounter: 0, Cart: null };
        window.setCartCount = count => {
            if (count < 0) return;
            var st = { ...this.state };
                st.goodsCount = count || null;
                this.setState(st);
        };

    }

    showCart() {
        if (window.showCart) window.showCart();
        else {
            var st = { ...this.state };
            st.Cart = <Cart/>;
            this.setState(st);
        }

    }

    render() {
        return <span><span className="cart-icon" onClick={() => this.showCart()}><span className="count">{this.state.goodsCount}</span> </span>{this.state.Cart}</span> ;
    }
}