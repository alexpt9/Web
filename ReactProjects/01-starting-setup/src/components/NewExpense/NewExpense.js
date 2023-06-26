import React, {useState} from "react";

import "./NewExpense.css";
import ExpenseForm from "./ExpenseForm";

const NewExpense = (props) => {
const [isEditing, setIsEditing] = useState(false);

  const saveExpenpenseDataHandler = (enetredExpenseData) => {
    const expenseData = {
      ...enetredExpenseData,
      id: Math.random().toString(),
    };
    props.onAddExpense(expenseData);
  };

  const editingHandler = () => {
    setIsEditing(true);
  }

  const stopEditingHandler = () => {
    setIsEditing(false);
  }

  return (
    <div className="new-expense">
      {!isEditing && <button onClick={editingHandler}>Add New Expense</button>}
      {isEditing && <ExpenseForm onStopEditingHandler={stopEditingHandler} onSaveExpenseData={saveExpenpenseDataHandler} />}
    </div>
  );
};

export default NewExpense;
