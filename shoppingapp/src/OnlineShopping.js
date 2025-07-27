// Cart.js
import React from 'react';

class Cart extends React.Component {
  render() {
    return (
      <div style={{ border: "1px solid gray", padding: "10px", margin: "10px" }}>
        <h3>Item: {this.props.itemname}</h3>
        <p>Price: ₹{this.props.price}</p>
      </div>
    );
  }
}

Cart.defaultProps = {
  itemname: "Default Item",
  price: 0
};

export default Cart;
