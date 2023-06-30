import React, { useState } from "react";

import logo from "./assets/investment-calculator-logo.png";

import NewCalculation from "./Components/NewCalculation/NewCalculation";
import Investments from "./Components/Investment/Investments";

function App() {
  const [isValid, setIsValid] = useState(false);
  const [investmentData, setInvestmentData] = useState([]);
  const calculateInvestmentHandler = (data) => {
    setIsValid(true);
    setInvestmentData({...data});
  };

  const resetHandler = () => {
    setIsValid(false);
  };

  return (
    <div>
      <header className="header">
        <img src={logo} alt="logo" />
        <h1>Investment Calculator</h1>
      </header>

      <NewCalculation onCalculateInvestment={calculateInvestmentHandler} onReset={resetHandler}/>
      {isValid && <Investments investmentData = {investmentData} />}
      {!isValid && <h1 className="header">No investment calculated yet</h1>}
    </div>
  );
}

export default App;
