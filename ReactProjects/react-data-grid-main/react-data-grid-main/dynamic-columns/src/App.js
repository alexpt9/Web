import './App.css';
import { DynamicColsGrid } from './dynamicColsGrid';
import React, { useState } from 'react';
import Login from './Component/Login/Login';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const loginHandler = () => {
    setIsLoggedIn(true);
    console.log(true);
  };

  return (
    <div>
      {!isLoggedIn && <Login onLogin={loginHandler} />}
      {isLoggedIn && <DynamicColsGrid />}
    </div>
  );
}

export default App;
