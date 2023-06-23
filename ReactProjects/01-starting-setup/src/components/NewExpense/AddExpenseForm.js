import "./ExpenseForm.css";

const AddExpenseForm = (props) => {
  const submitHandler = () => {
    props.onAddExpense();
  };

  return (
    <form onSubmit={submitHandler}>
      <div className="new-expense__controls">
        <button type="submit">Add new expense</button>
      </div>
    </form>
  );
};

export default AddExpenseForm;
