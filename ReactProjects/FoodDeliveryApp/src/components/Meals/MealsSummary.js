import classes from './MealsSummary.module.css';

const MealsSummary = () => {
  return (
    <section className={classes.summary}>
      <h2>Delicious Food, Delivered to you</h2>
      <p>
        Choose your favourite meal from our broad selection of available meals
        and enjoy a delecious lunch or dinner at home.
      </p>
      <p>
        All our meals are cooked withhigh-quality ingredients, just-in-time and
        of course through experienced chefs!
      </p>
    </section>
  );
};

export default MealsSummary;
