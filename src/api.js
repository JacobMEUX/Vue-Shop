/* eslint-disable no-console */
const axios = require("axios");
const api = axios.create({
  baseURL: process.env.VUE_APP_API_PATH,
  timeout: 4000
});

function get(url) {
  try {
    return api.get(url);
  } catch (error) {
    console.log(error);
  }
}

export default {
  getBrands: () => {
    return get("/brands");
  },
  getClothes: () => {
    return get("/clothing");
  },
  getClothesById: id => {
    return get("/clothing/" + id);
  }
};
