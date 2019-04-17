<template>
  <div>
    <a-form layout="vertical" hideRequiredMark>
      <a-form-item label="Title">
        <a-input
          v-model="title"
          v-decorator="['Title', {
                  rules: [{ required: true, message: 'Please enter a title' }]
                }]"
          placeholder="Please enter a title"
        />
      </a-form-item>

      <a-form-item label="Description">
        <a-textarea
          v-model="description"
          v-decorator="['description', {
                  rules: [{ required: true, message: 'Please enter url description' }]
                }]"
          :rows="4"
          placeholder="please enter url description"
        />
      </a-form-item>

      <a-form-item label="Category">
        <a-select
          v-model="category"
          showSearch
          placeholder="Please select a category"
          optionFilterProp="children"
          :filterOption="filterOption"
          v-decorator="['category', {
                  rules: [{ required: true, message: 'Please select a category' }]
                }]"
        >
          <a-select-option
            v-for="category in categories"
            :key="category.categoryId"
            :value="category.categoryId"
          >{{category.name}}</a-select-option>
        </a-select>
      </a-form-item>

      <a-form-item label="Brand">
        <a-select
          v-model="brand"
          showSearch
          placeholder="Please select a brand"
          optionFilterProp="children"
          :filterOption="filterOption"
          v-decorator="['brand', {
                  rules: [{ required: true, message: 'Please select a brand' }]
                }]"
        >
          <a-select-option
            v-for="brand in brands"
            :key="brand.brandId"
            :value="brand.brandId"
          >{{brand.name}}</a-select-option>
        </a-select>
        <a-form-item label="Price">
          <a-input
            v-model="price"
            step="0.01"
            v-decorator="['price', {
                  rules: [{ required: true, message: 'Please enter a price' }]
                }]"
            :rows="4"
            placeholder="Please enter a price"
            addonAfter="DKK"
            type="number"
          />
        </a-form-item>
      </a-form-item>
    </a-form>
  </div>
</template>

<script>
export default {
  props: {
    onCancel: Function
  },
  data() {
    return {
      brands: [],
      categories: [],
      title: "",
      description: "",
      brand: null,
      category: null,
      price: null
    };
  },
  created: function() {
    this.$api.getBrands().then(response => {
      this.brands = response.data;
    });

    this.$api.getCategories().then(response => {
      this.categories = response.data;
    });
  },
  methods: {
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