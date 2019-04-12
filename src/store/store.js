import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export const mutations = {
  Add_Clothing: "AddClothing"
};

const store = new Vuex.Store({
  state: {
    items: [
      {
        image:
          "https://cdn.shopify.com/s/files/1/0192/2956/products/303624_Terra_Kids_Kneifzange_F_01_2000x.jpg?v=1529663344",
        name: "Knibtang til børn",
        description:
          "Praktisk knibtang fra Haba, solid og i stål. Perfekt til brug af den lille handyman.",
        price: 70
      },
      {
        image:
          "https://cdn.shopify.com/s/files/1/0192/2956/products/303625_Terra_Kids_Hammer_F_01_2000x.jpg?v=1530003333",
        name: "Haba hammer",
        description:
          "Solid og praktisk hammer med grønt håndtag i gummi. Perfekt til brug af den lille handyman.",
        price: 100
      }
    ]
  },
  mutations: {
    increment(state, payload) {
      // API kald til at tilføje det til databasen
      state.items.push(payload);
    }
  }
});

export default store;
