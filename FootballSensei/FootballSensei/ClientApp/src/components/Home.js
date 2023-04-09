import React, { Component } from 'react';
import { Matches } from './Matches';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <Matches />
      </div>
    );
  }
}
