<template>
  <a-drawer
    title="Cart"
    placement="right"
    :width="720"
    :closable="false"
    @close="onCloseCart"
    :visible="showCart"
  >
    <CartItem v-for="item in cart" v-bind:key="item.id" :item="item"/>
    <a-row class="row-margin">
      <a-row>
        <h5>{{totalPrice}} DKK</h5>
      </a-row>
      <a-row>
        <a-button type="primary" :loading="loading" icon="shopping-cart" @click="onOrderClick">Order</a-button>
      </a-row>
    </a-row>
  </a-drawer>
</template>

<script>
import { mapState } from "vuex";
import { actions } from "../../store";
import CartItem from "./CartItem";
import { setTimeout } from "timers";

export default {
  components: {
    CartItem
  },
  data: function() {
    return {
      showCart: false,
      loading: false
    };
  },
  computed: {
    ...mapState(["cart"]),
    totalPrice: function() {
      if (this.cart.length == 1) {
        return this.cart[0].price;
      } else if (this.cart.length > 1) {
        return this.cart.reduce((total, item) => total + item.price, 0);
      } else {
        return "";
      }
    }
  },
  methods: {
    onShowCart() {
      this.showCart = true;
    },
    onCloseCart() {
      this.showCart = false;
    },
    onOrderClick() {
      this.loading = true;
      
      setTimeout(() => {
        this.showCart = false;
        this.loading = false;
        // ToDo: Make API call to place order
        this.$message.success("Order placed");
        this.$store.dispatch(actions.clearCart);
      }, 1000);
    }
  }
};
</script>
