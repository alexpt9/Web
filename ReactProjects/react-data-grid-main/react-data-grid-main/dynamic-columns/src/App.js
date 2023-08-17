import './App.css';

import React, { useState, Fragment } from 'react';
import Login from './Component/Login/Login';
import Tabs from './Component/UI/Tabs';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const loginHandler = () => {
    setIsLoggedIn(true);
    console.log(true);
  };

  return (
    <Fragment>
      {!isLoggedIn && <Login onLogin={loginHandler} />}
      {isLoggedIn && <Tabs />}
    </Fragment>
  );
}

export default App;
