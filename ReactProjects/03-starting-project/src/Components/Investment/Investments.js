import React from "react";

import classes from "./Investments.module.css";

const formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
})

const Investments = (props) => {
  const yearlyData = [];
  let currentSavings = props.investmentData["currentSaving"]; // feel free to change the shape of this input object!
  const yearlyContribution = props.investmentData["yearlySavings"]; // as mentioned: feel free to change the shape...
  const expectedReturn = props.investmentData["expectedInterest"] / 100;
  const duration = props.investmentData["investmentDuration"];

  let totalInterest = 0;
  let investedCapital = 0;
  // The below code calculates yearly results (total savings, interest etc)
  for (let i = 0; i < duration; i++) {
    const yearlyInterest = currentSavings * expectedReturn;
    currentSavings += yearlyInterest + yearlyContribution;
    totalInterest += yearlyInterest;
    investedCapital += currentSavings + yearlyContribution;

    yearlyData.push({
      // feel free to change the shape of the data pushed to the array!
      year: i + 1,
      yearlyInterest: yearlyInterest,
      savingsEndOfYear: currentSavings,
      yearlyContribution: yearlyContribution,
      totalInterest: totalInterest,
      investedCapital: investedCapital,
    });
  }

  return (
    <table className={classes.result}>
      <thead>
        <tr>
          <th>Year</th>
          <th>Total Savings</th>
          <th>Interest (Year)</th>
          <th>Total Interest</th>
          <th>Invested Capital</th>
        </tr>
      </thead>
      <tbody>
        { yearlyData.map(data =>(
          <tr key={data.year}>
            <td>{data.year}</td>
            <td>{formatter.format(data.savingsEndOfYear)}</td>
            <td>{formatter.format(data.yearlyInterest)}</td>
            <td>{formatter.format(data.totalInterest)}</td>
            <td>{formatter.format(data.investedCapital)}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default Investments;
