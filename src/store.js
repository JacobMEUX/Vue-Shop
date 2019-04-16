/* eslint-disable no-console */
import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export const actions = {
  addToCart: "addToCart",
  removeFromCart: "removeFromCart",
  clearCart: "clearCart"
};

export const getters = {
  cartCount: "cartCount",
};

const _mutations = {
  addToCart: "addToCart",
  removeFromCart: "removeFromCart",
  clearCart: "clearCart",
};

const store = new Vuex.Store({
  state: {
    cart: []
  },
  mutations: {
    addToCart(state, payload) {
      state.cart.push(payload);
    },
    removeFromCart(state, payload) {
      state.cart.splice(payload, 1);
    },
    clearCart(state) {
      state.cart = [];
    }
  },
  actions: {
    addToCart: function({ commit }, cartItem) {
      commit(_mutations.addToCart, cartItem);
    },
    removeFromCart: function({ commit }, index) {
      commit(_mutations.removeFromCart, index);
    },
    clearCart: function({ commit }) {
      commit(_mutations.clearCart);
    }
  },
  getters: {
    cartCount: state => {
      return state.cart.length;
    }
  }
});

export default store;