<template>
  <div>
    <a-row>
      <a-col :span="4" class="col-margin" style="margin-right: 2%">
        <a-form>
          <a-form-item label="Search">
            <a-input-search v-model="search" placeholder="Search..." @change="onSearchChange"/>
          </a-form-item>

          <a-form-item label="Brand">
            <a-select
              v-model="brand"
              showSearch
              placeholder="Please select a brand"
              optionFilterProp="children"
              :filterOption="filterOption"
            >
              <a-select-option
                v-for="brand in brands"
                :key="brand.brandId"
                :value="brand.brandId"
              >{{brand.name}}</a-select-option>
            </a-select>
          </a-form-item>

          <a-form-item label="Category">
            <a-select
              v-model="category"
              showSearch
              placeholder="Please select a category"
              optionFilterProp="children"
              :filterOption="filterOption"
            >
              <a-select-option
                v-for="category in categories"
                :key="category.categoryId"
                :value="category.categoryId"
              >{{category.name}}</a-select-option>
            </a-select>
          </a-form-item>
        </a-form>
      </a-col>
      <a-col :span="19">
        <ItemCards :items="items"/>
      </a-col>
    </a-row>
  </div>
</template>

<script>
import ItemCards from "../items/ItemCards";

export default {
  components: {
    ItemCards
  },
  data: function() {
    return {
      search: "",
      categories: [],
      category: null,
      brands: [],
      brand: null,
      items: []
    };
  },
  created: async function() {
    this.$api.getClothes().then(response => {
      this.items = response.data;
    });

    this.$api.getBrands().then(response => {
      this.brands = response.data;
    });

    this.$api.getCategories().then(response => {
      this.categories = response.data;
    });
  },
  methods: {
    onSearchChange: function() {},
    filterOption(input, option) {
      return (
        option.componentOptions.children[0].text
          .toLowerCase()
          .indexOf(input.toLowerCase()) >= 0
      );
    }
  }
};
</script>