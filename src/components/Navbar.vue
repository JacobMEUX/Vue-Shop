<template>
  <div>
    <a-menu mode="horizontal">
      <a-menu-item key="mail">
        <a-icon type="mail"/>Navigation One
      </a-menu-item>
      <a-menu-item key="app" disabled>
        <a-icon type="appstore"/>Navigation Two
      </a-menu-item>
      <a-menu-item @click="onShowCartClick" :selectable="false" :disabled="!cartCount">
        <a-badge :count="cartCount">
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
import { mapGetters } from "vuex";
import CartDrawer from "./cart/CartDrawer"
import { getters } from '../store';

export default {
  components: {
    CartDrawer
  },
  computed: {
    ...mapGetters([
    getters.cartCount
  ])
  },
  methods: {
    onShowCartClick() {
      this.$refs.cartdrawer.showCart = true;
    }
  }
};
</script>
