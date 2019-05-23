import React, { Component } from 'react';
import {DataTable} from './DataTable.js';
import './goodsList.css';
import { Cart } from './Cart.js';

export class GoodsList extends Component {
    static displayName = GoodsList.name;

    constructor(props) {
        super(props);
    }


    objectConverter(object) {
        return {
            Image: (<img src={'/Images/' + object.id + '.jpg'} className="good-img" onError={(e) => {
                e.target.onerror = null;
                e.target.src = '/Images/no_foto.jpg'
            }} />),
            Description: <span>{object.description}</span>,
            StorageCount: <span>{object.storageCount + 'רע.'}</span>,
            AddToCart: <button className="btn btn-primary" onClick={() => {
                window.addToCart(object); }}>To cart</button>
        };
    }
    render() {
        return (
            <div>
                <DataTable pageLen='3' url='api/Goods/WeatherForecasts2' objectConverter={this.objectConverter} /> 
            </div>
    );
}
}