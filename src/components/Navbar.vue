<template>
  <div>
    <a-menu mode="horizontal">
      <a-menu-item key="mail">
        <a-icon type="mail"/>Navigation One
      </a-menu-item>
      <a-menu-item key="app" disabled>
        <a-icon type="appstore"/>Navigation Two
      </a-menu-item>
      <a-menu-item @click="onShowCartClick" :selectable="false">
        <a-badge :count="cart">
          <a href="#" class="head-example" >
            <a-icon type="shopping" :style="{ fontSize: '1.5em' }"/>
          </a>
        </a-badge>
      </a-menu-item>
    </a-menu>

    <CartDrawer ref="cartdrawer"/>
  </div>
</template>

<script>
import { mapState } from "vuex";
import CartDrawer from "./cart/CartDrawer"

export default {
  components: {
    CartDrawer
  },
  computed: mapState(["cart"]),
  methods: {
    onShowCartClick() {
      this.$refs.cartdrawer.showCart = true;
    }
  }
};
</script>
