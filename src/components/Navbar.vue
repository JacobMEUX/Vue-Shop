<template>
  <div>
    <a-menu mode="horizontal">
      <a-menu-item>
        <router-link to="/">
          <a-icon type="shop" :style="{ fontSize: '1.5em' }"/>Store
        </router-link>
      </a-menu-item>
      <a-menu-item @click="onShowCartClick" :disabled="!cartCount">
        <a-badge :count="cartCount">
          <a href="#" class="head-example">
            <a-icon type="shopping" :style="{ fontSize: '1.5em' }"/>
          </a>
        </a-badge>
      </a-menu-item>
      <a-menu-item>
        <NewItem>
          <a href="#" class="head-example">
            <a-icon type="plus" :style="{ fontSize: '1.5em' }"/>
          </a>
        </NewItem>
      </a-menu-item>
    </a-menu>
    <CartDrawer ref="cartdrawer"/>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { getters } from "../store";
import CartDrawer from "./cart/CartDrawer";
import NewItem from "./modals/NewItem";

export default {
  components: {
    CartDrawer,
    NewItem
  },
  computed: {
    ...mapGetters([getters.cartCount])
  },
  methods: {
    onShowCartClick() {
      this.$refs.cartdrawer.showCart = true;
    }
  }
};
</script>