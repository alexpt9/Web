import React, { useState } from "react";

import "./NewCalculation.css";

const NewCalculation = (props) => {
  const [enteredCurrentSaving, setEnteredCurrentSaving] = useState("");
  const [enteredYearlySavings, setEnteredYearlySavings] = useState("");
  const [enteredExpectedInterest, setEnteredExpectedInterest] = useState("");
  const [enteredInvestmentDuration, setEnteredInvestmentDuration] =
    useState("");

  const inputChangeHandler = (identifier, value) => {
    if (identifier === "current") {
      setEnteredCurrentSaving(value);
    } else if (identifier === "yearly") {
      setEnteredYearlySavings(value);
    } else if (identifier === "interest") {
      setEnteredExpectedInterest(value);
    } else {
      setEnteredInvestmentDuration(value);
    }
  };

  return (
    <form className="form">
      <div className="input-group">
        <div>
          <label>curent savings (S))</label>
          <input
            type="number"
            step={1}
            onChange={(event) =>
              inputChangeHandler("current", event.target.value)
            }
          ></input>
        </div>
        <div>
          <label>yearly savings (S))</label>
          <input
            type="number"
            step={1}
            onChange={(event) =>
              inputChangeHandler("yearly", event.target.value)
            }
          ></input>
        </div>
      </div>
      <div className="input-group">
        <div>
          <label>expected interest (%, per year))</label>
          <input
            type="number"
            step={1}
            onChange={(event) =>
              inputChangeHandler("interest", event.target.value)
            }
          ></input>
        </div>
        <div>
          <label>investment duration (years))</label>
          <input
            type="number"
            step={1}
            onChange={(event) =>
              inputChangeHandler("duration", event.target.value)
            }
          ></input>
        </div>
      </div>
      <div className="actions">
        <button className="buttonAlt">Reset</button>
        <button type="submit" className="button">
          Calculate
        </button>
      </div>
    </form>
  );
};

export default NewCalculation;
