import React, { Component } from "react";
import Service from './Common/Service';

class App extends Component {
  render() {
    return (
      <div className="App Container mx-2">
        <h1>Accounts App</h1>
        <Service />
      </div>
    );
  }
}

export default App;
