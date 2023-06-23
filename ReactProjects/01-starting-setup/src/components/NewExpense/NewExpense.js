import React from "react";

import "./NewExpense.css";
import AddExpenseForm from "./AddExpenseForm";
import ExpenseForm from "./ExpenseForm";

let isAddexpenseForm = true;
const NewExpense = (props) => {
  const saveExpenpenseDataHandler = (enetredExpenseData) => {
    const expenseData = {
      ...enetredExpenseData,
      id: Math.random().toString(),
    };
    props.onAddExpense(expenseData);
    isAddexpenseForm = false
  };

  const addExpenseHandler = () => {
    isAddexpenseForm = false;
  }

  if (isAddexpenseForm) {
    return <AddExpenseForm onAddExpense={addExpenseHandler}/>;
  }

  return (
    <div className="new-expense">
      <ExpenseForm onSaveExpenseData={saveExpenpenseDataHandler} />
    </div>
  );
};

export default NewExpense;
