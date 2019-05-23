import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Cart } from './Cart.js';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div><Cart visible={false}/>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
