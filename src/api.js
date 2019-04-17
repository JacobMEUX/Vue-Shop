/* eslint-disable no-console */
const axios = require("axios");
const api = axios.create({
  baseURL: process.env.VUE_APP_API_PATH,
  timeout: 4000
});

export default {
  getBrands: () => {
    return _get("/brand");
  },
  getCategories: () => {
    return _get("/category");
  },
  getClothes: () => {
    return _get("/clothing");
  },
  insertClothes: (payload) => {
    return _post("/clothing", payload);
  },
  getClothesById: id => {
    return _get("/clothing/" + id);
  },
  deleteClothesById: id => {
    return _delete("/clothing/" + id);
  }
};

function _get (url) {
  try {
    return api.get(url);
  } catch (error) {
    console.log(error);
  }
}

function _delete (url) {
  try {
    return api.delete(url);
  } catch (error) {
    console.log(error);
  }
}

function _post (url, payload) {
  try {
    return api.post(url, payload);
  } catch (error) {
    console.log(error);
  }
}

