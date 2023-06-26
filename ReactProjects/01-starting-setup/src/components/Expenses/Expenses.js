import React, { useState } from "react";

import "./Expenses.css";
import ExpensesList from "./ExpensesList";
import Card from "../UI/Card";
import ExpensesFilter from "./ExpenseFilter";
import ExpenseChart from "./ExpensesChart";

const Expenses = (props) => {
  const [receivedYear, setReceivedYear] = useState("2020");
  const filteredExpenses = props.expenses.filter(
    (expence) => receivedYear === expence.date.getFullYear().toString()
  );

  const YearReceivedHandler = (year) => {
    setReceivedYear(year);
    console.log(year);
  };


  return (
    <div>
      <Card className="expenses">
        <ExpensesFilter
          selected={receivedYear}
          onYearReceived={YearReceivedHandler}
        />
        <ExpenseChart expenses={filteredExpenses}/>
        <ExpensesList filteredExpenses={filteredExpenses}/>
      </Card>
    </div>
  );
};

export default Expenses;
