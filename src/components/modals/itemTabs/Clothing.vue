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
                  rules: [{ required: true, message: 'Please enter a description' }]
                }]"
          :rows="4"
          placeholder="Please enter a description"
        />
      </a-form-item>

      <a-form-item label="Price">
          <a-input
            v-model="price"
            step="0.01"
            v-decorator="['price', {
                  rules: [{ required: true, message: 'Please enter a price' }]
                }]"
            placeholder="Please enter a price"
            addonAfter="DKK"
            type="number"
          />
        </a-form-item>

        <a-form-item label="Image">
          <a-input
            v-model="image"
            v-decorator="['Image', {
                  rules: [{ required: true, message: 'Please enter an image url' }]
                }]"
            placeholder="Please enter an image url"
          />
        </a-form-item>
    </a-form>
  </div>
</template>

<script>
export default {
  props: {
    onCancel: Function,
    item: Object
  },
  data() {
    return {
      title: "",
      description: "",
      price: 250,
      image: ""
    };
  },
  created: function () {
    if (this.item) {
      this.title = this.item.title;
      this.description = this.item.description;
      this.price = this.item.price;
      this.image = this.item.image.url;
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