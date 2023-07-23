import React, { useState } from "react";

import "./NewCalculation.css";

const NewCalculation = (props) => {
  const [enteredCurrentSaving, setEnteredCurrentSaving] = useState("10000");
  const [enteredYearlySavings, setEnteredYearlySavings] = useState("1200");
  const [enteredExpectedInterest, setEnteredExpectedInterest] = useState("5");
  const [enteredInvestmentDuration, setEnteredInvestmentDuration] =
    useState("5");

  const inputChangeHandler = (identifier, event) => {
    if (identifier === "current") {
      setEnteredCurrentSaving(event.target.value);
    } else if (identifier === "yearly") {
      setEnteredYearlySavings(event.target.value);
    } else if (identifier === "interest") {
      setEnteredExpectedInterest(event.target.value);
    } else {
      setEnteredInvestmentDuration(event.target.value);
    }
    event.stopPropagation();
  };

  const submitHandler = (event) => {
    event.preventDefault();
    event.stopPropagation();
    if (
      enteredCurrentSaving === "" ||
      enteredExpectedInterest === "" ||
      enteredInvestmentDuration === "" ||
      enteredYearlySavings === ""
    ) {
      return;
    }
    const data = {
      currentSaving: +enteredCurrentSaving,
      yearlySavings: +enteredYearlySavings,
      expectedInterest: +enteredExpectedInterest,
      investmentDuration: +enteredInvestmentDuration,
    };
    console.log(data);
    props.onCalculateInvestment(data);
    setEnteredCurrentSaving(enteredCurrentSaving);
    setEnteredYearlySavings(enteredYearlySavings);
    setEnteredExpectedInterest(enteredExpectedInterest);
    setEnteredInvestmentDuration(enteredInvestmentDuration);
  };

  return (
    <form className="form" onSubmit={submitHandler}>
      <div className="input-group">
        <div>
          <label>curent savings (S))</label>
          <input
            type="number"
            min={1}
            value={enteredCurrentSaving}
            step={1}
            onChange={(event) =>
              inputChangeHandler("current", event)
            }
          />
        </div>
        <div>
          <label>yearly savings (S))</label>
          <input
            type="number"
            min={1}
            step={1}
            value={enteredYearlySavings}
            onChange={(event) =>
              inputChangeHandler("yearly", event)
            }
          />
        </div>
      </div>
      <div className="input-group">
        <div>
          <label>expected interest (%, per year))</label>
          <input
            type="number"
            min={1}
            step={1}
            value={enteredExpectedInterest}
            onChange={(event) =>
              inputChangeHandler("interest", event)
            }
          />
        </div>
        <div>
          <label>investment duration (years))</label>
          <input
            type="number"
            min={1}
            step={1}
            value={enteredInvestmentDuration}
            onChange={(event) =>
              inputChangeHandler("duration", event)
            }
          />
        </div>
      </div>
      <div className="actions">
        <button className="buttonAlt" type="button" onClick={props.onReset}>
          Reset
        </button>
        <button type="submit" className="button">
          Calculate
        </button>
      </div>
    </form>
  );
};

export default NewCalculation;
