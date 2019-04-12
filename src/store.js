/* eslint-disable no-console */
import Vue from "vue";
import Vuex from "vuex";
import api from "./api";

Vue.use(Vuex);

export const actions = {
  Fecth_Data: "fetchData",
  Add_ToCart: "addToCart"
};

const _mutations = {
  Add_Clothing: "addClothing",
  Add_Brand: "addBrand",
  Add_ToCart: "addToCart",
  Fetch_Data: "fetchData"
};

const store = new Vuex.Store({
  state: {
    clothes: [],
    brands: [],
    cart: 0
  },
  mutations: {
    addClothing(state, payload) {
      // API kald til at tilføje det til databasen
      state.clothes.push(payload);
    },
    addBrand(state, payload) {
      state.brands.push(payload);
    },
    addToCart(state) {
      state.cart++;
    },
    fetchData: async function (state) {
      state.brands = await api.getBrands();
      state.clothes = await api.getClothes();
    }
  },
  actions: {
    fetchData: async function() {
      store.commit(_mutations.Fetch_Data);
    },
    addToCart: function () {
      store.commit(_mutations.Add_ToCart);
    }
  }
});

export default store;
