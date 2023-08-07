import { useContext } from 'react';

import classes from './Cart.module.css';

import Modal from '../UI/Modal';
import CartContext from '../../store/cart-context';
import CartItem from './CartItem';

const Cart = (props) => {
  const cartCntx = useContext(CartContext);
  const cartTotalAmount = `$${cartCntx.totalAmount.toFixed(2)}`;
  const hasItems = cartCntx.items.length > 0;

  const removeItemHandler = (id) => {
    cartCntx.removeItem(id);
  };

  const addToCartHandler = (item) => {
    cartCntx.addItem(item);
  };

  const cartItems = (
    <ul className={classes['cart-item']}>
      {cartCntx.items.map((item) => (
        <CartItem
          key={item.id}
          name={item.name}
          price={item.price}
          amount={item.amount}
          onRemove={removeItemHandler.bind(null, item.id)}
          onAdd={addToCartHandler.bind(null, item)}
        />
      ))}
    </ul>
  );
  return (
    <Modal onClose={props.onClose}>
      {cartItems}
      <div className={classes.total}>
        <span>Total Amount</span>
        <span>{cartTotalAmount}</span>
      </div>
      <div className={classes.actions}>
        <button className={classes['button--alt']} onClick={props.onClose}>
          Close
        </button>
        {hasItems && <button className={classes.button}>Order</button>}
      </div>
    </Modal>
  );
};

export default Cart;
