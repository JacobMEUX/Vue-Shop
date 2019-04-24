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
          <Clothing :item="item" v-show="selected === 'clothing'" ref="clothingForm"/>
          <Brand :brandIdProp="item.fkBrandId" v-show="selected === 'brand'" ref="brandForm"/>
          <Category
            :categoryIdProp="item.fkCategoryId"
            v-show="selected === 'category'"
            ref="categoryForm"
          />
        </div>
      </a-card>
      <template slot="footer">
        <a-button key="back" @click="onClose">Cancel</a-button>
        <a-button key="submit" type="primary" :loading="updating" @click.prevent="onUpdate">Update</a-button>
      </template>
    </a-modal>
  </div>
</template>

<script>
import Clothing from "./itemTabs/Clothing";
import Category from "./itemTabs/Category";
import Brand from "./itemTabs/Brand";

import itemTabsMixin from "../../mixins/itemTabs.js";

export default {
  components: {
    Clothing,
    Category,
    Brand
  },
  mixins: [itemTabsMixin],
  props: {
    itemProp: Object,
    onEdit: Function
  },
  data: function() {
    return {
      updating: false,
      visible: false,
      item: this.itemProp
    };
  },
  methods: {
    showModal() {
      this.visible = true;
    },
    onClose() {
      this.visible = false;
    },
    onUpdate() {
      this.updating = true;
      const brandObject = this.$refs.brandForm.brands.find(obj => {
        return obj.brandId == this.$refs.brandForm.brandId;
      });

      const categoryObject = this.$refs.categoryForm.categories.find(obj => {
        return obj.categoryId == this.$refs.categoryForm.categoryId;
      });

      const dto = {
        clothingId: this.item.clothingId,
        title: this.$refs.clothingForm.title,
        description: this.$refs.clothingForm.description,
        price: parseFloat(this.$refs.clothingForm.price),
        brand: brandObject,
        category: categoryObject,
        image: {
          altText: this.$refs.clothingForm.title,
          url: this.$refs.clothingForm.image
        }
      };

      this.$api
        .updateClothes(this.item.clothingId, dto)
        .then(() => {
          this.$message.success("The item has been created");
          this.onEdit(dto);
          this.visible = false;
        })
        .catch(err => {
          this.$message.error(err);
        })
        .finally(() => {
          this.updating = false;
        });
    }
  }
};
</script>