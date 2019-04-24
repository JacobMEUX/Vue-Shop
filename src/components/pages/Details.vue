<template>
  <div>
    <a-spin :spinning="isLoaded" tip="Loading...">
      <div class="spin-content">
        <a-row :gutter="48" v-if="!isLoaded">
          <a-col :span="8">
            <a-card>
              <img :alt="item.image.altText" :src="imageUrl" slot="cover">
            </a-card>
          </a-col>
          <a-col :span="16">
            <a-card :title="item.title">
              <h3>{{item.brand.name}}</h3>
              <h4>{{item.price}} DKK</h4>
              <p>{{item.description}}</p>
              <template class="ant-card-actions" slot="actions">
                <EditItem :itemProp="item" :onEdit="onProductChange">
                  <a-icon type="form"/>
                </EditItem>
                <a-icon type="delete" @click="onDeleteClick"/>
                <AddToCart :item="item">
                  <a-icon type="shopping"/>
                </AddToCart>
              </template>
            </a-card>
          </a-col>
        </a-row>
      </div>
    </a-spin>
  </div>
</template>

<script>
import AddToCart from "../cart/AddToCart";
import EditItem from "../modals/EditItem";

export default {
  components: {
    AddToCart,
    EditItem
  },
  props: [
    "id",
    "sentItem"
    ],
  data: function() {
    return {
      item: null
    };
  },
  created: function() {
    // If an item was sent as a prop then it uses that.
    // else it gets the item from the API.
    if (!this.sentItem) {
      this.$api.getClothesById(this.id).then(response => {
        this.item = response.data;
      });
    } else {
      this.item = this.sentItem;
    }
  },
  computed: {
    isLoaded: function() {
      return this.item === null;
    },
    imageUrl: function() {
      return this.item.image.url.includes("Images/")
        ? "/" + this.item.image.url
        : this.item.image.url;
    }
  },
  methods: {
    onDeleteClick: function() {
      const hide = this.$message.loading("Deleting item..", 0);
      this.$api.deleteClothesById(this.id).then(() => {
        hide();
        this.$message.success("Item has been deleted");
        this.$router.push({ name: "store" });
      });
    },
    onProductChange: function(changedItem) {
      this.item = changedItem;
    }
  }
};
</script>