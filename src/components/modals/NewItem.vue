<template>
  <div>
    <div @click="showModal">
      <slot/>
    </div>
    <a-modal v-model="visible" :closable="false" :maskClosable="false">
      <a-card
        style="width:100%"
        :tabList="tabList"
        :activeTabKey="selected"
        @tabChange="key => onTabChange(key, 'selected')"
      >
        <div>
          <Clothing v-if="selected === 'clothing'" ref="clothingForm"/>
          <Brand v-else-if="selected === 'brand'" ref="brandForm"/>
          <Category v-else-if="selected === 'category'" ref="categoryForm"/>
        </div>
      </a-card>
      <template slot="footer">
        <a-button key="back" @click="onClose">Cancel</a-button>
        <a-button key="submit" type="primary" :loading="creating" @click.prevent="onCreate">Create</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script>
import Clothing from "./newItemTabs/Clothing";
import Category from "./newItemTabs/Category";
import Brand from "./newItemTabs/Brand";

export default {
  components: {
    Clothing,
    Category,
    Brand
  },
  data() {
    return {
      creating: false,
      visible: false,
      key: "clothing",
      selected: "clothing",
      tabList: [
        {
          key: "clothing",
          tab: "Clothing"
        },
        {
          key: "brand",
          tab: "Brand"
        },
        {
          key: "category",
          tab: "Category"
        }
      ]
    };
  },
  methods: {
    showModal() {
      this.visible = true;
    },
    onTabChange(key, type) {
      this[type] = key;
    },
    onClose() {
      this.visible = false;
    },
    onCreate() {
      this.creating = true;
      let dto = {};
      if (this.key === "clothing") {
        dto = {
          title: this.$refs.clothingForm.title,
          description: this.$refs.clothingForm.description,
          fkCategoryId: this.$refs.clothingForm.category,
          fkBrandId: this.$refs.clothingForm.brand,
          price: parseFloat(this.$refs.clothingForm.price),
          image: {
            altText: "this.$refs.clothingForm.title",
            url: this.$refs.clothingForm.image
          }
        };
      } else if (this.key === "brand") {
        dto = {};
      } else if (this.key === "category") {
        dto = {};
      }

      setTimeout(() => {
        this.$api
          .insertClothes(dto)
          .then(() => {
            this.$message.success("The item has been created");
            this.visible = false;
          })
          .catch(err => {
            this.$message.error(err);
          })
          .finally(() => {
            this.creating = false;
          });
      }, 1000);
    }
  }
};
</script>