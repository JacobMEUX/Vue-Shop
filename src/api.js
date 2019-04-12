/* eslint-disable no-console */
const axios = require("axios");
const api = axios.create({
  baseURL: process.env.VUE_APP_API_PATH,
  timeout: 4000
});

export default {
  getBrands: async () => {
    try {
      return (await api.get("/brand")).data;
    } catch (error) {
      console.log(error);
    }
  },
  getClothes: async () => {
    try {
      return (await api.get("/clothing")).data;
    } catch (error) {
      console.log(error);
    }
  }
};
