<template>
  <div>
    <a-form layout="vertical" hideRequiredMark>
      <a-form-item label="Brand">
        <a-select
          v-model="categoryId"
          showSearch
          placeholder="Please select a category"
          optionFilterProp="children"
          :filterOption="filterOptions"
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
    </a-form>
  </div>
</template>

<script>
import selectFilter from "../../../mixins/selectFilter.js"

export default {
  props: {
    categoriesProp: Array,
    categoryIdProp: Number
  },
  mixins: [selectFilter],
  data: function() {
    return {
      categoryId: this.categoryIdProp,
      categories: this.categoriesProp
    };
  },
  created: function() {
    if (!this.categoriesProp) {
      this.$api.getCategories().then(response => {
        this.categories = response.data;
      });
    }
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
