<template>
  <div>
    <a-row>
      <a-col :span="4" class="col-margin" style="margin-right: 2%">
        <a-row>
          <a-input-search v-model="search" placeholder="Search..." @change="onSearchChange"/>
        </a-row>
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
  data: function () {
    return {
      search: "",
      items: []
    }
  },
  created: async function () {
    this.$api.getClothes().then((response) => {
      this.items = response.data;
    });
  },
  methods: {
    onSearchChange: function () {
      
    }
  }
};
</script>