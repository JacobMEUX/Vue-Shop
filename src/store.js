/* eslint-disable no-console */
import Vue from "vue";
import Vuex from "vuex";
import api from "./api";

Vue.use(Vuex);

export const actions = {
  fetchData: "fetchData",
  addToCart: "addToCart",
  clearCart: "clearCart"
};

export const getters = {
  cartCount: "cartCount"
};

const _mutations = {
  addClothing: "addClothing",
  addBrand: "addBrand",
  addToCart: "addToCart",
  clearCart: "clearCart",
  fetchData: "fetchData"
};

const store = new Vuex.Store({
  state: {
    clothes: [],
    brands: [],
    cart: []
  },
  mutations: {
    addClothing(state, payload) {
      // API kald til at tilføje det til databasen
      state.clothes.push(payload);
    },
    addBrand(state, payload) {
      // API kald til at tilføje det til databasen
      state.brands.push(payload);
    },
    addToCart(state, payload) {
      state.cart.push(payload);
    },
    clearCart(state) {
      state.cart = [];
    },
    fetchData: async function(state) {
      state.brands = await api.getBrands();
      state.clothes = await api.getClothes();
    }
  },
  actions: {
    fetchData: async function({ commit }) {
      commit(_mutations.fetchData);
    },
    addToCart: function({ commit }, cartItem) {
      commit(_mutations.addToCart, cartItem);
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
