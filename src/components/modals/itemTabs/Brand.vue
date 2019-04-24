<template>
  <div>
    <a-form layout="vertical" hideRequiredMark>
      <a-form-item label="Brand">
        <a-select
          v-model="brandId"
          showSearch
          placeholder="Please select a brand"
          optionFilterProp="children"
          :filterOption="filterOptions"
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
      </a-form-item>
    </a-form>
  </div>
</template>

<script>
import selectFilter from "../../../mixins/selectFilter.js"

export default {
  props: {
    brandsProp: Array,
    brandIdProp: Number
  },
  mixins: [selectFilter],
  data: function() {
    return {
      brandId: this.brandIdProp,
      brands: this.brandsProp
    };
  },
  created: function() {
    if (!this.brandsProp) {
      this.$api.getBrands().then(response => {
        this.brands = response.data;
      });
    }
  }
};
</script>
