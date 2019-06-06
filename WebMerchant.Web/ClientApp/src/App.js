import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { GoodsList } from './components/goodsList';
import { Counter } from './components/Counter';
import { Checkout } from './components/Checkout';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
            <Route path='/goods-list' component={GoodsList} />
            <Route path='/checkout' component={Checkout} />
      </Layout>
    );
  }
}
