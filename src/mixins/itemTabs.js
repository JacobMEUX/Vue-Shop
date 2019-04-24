export default {
  data: function() {
    return {
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
    onTabChange(key, type) {
      this[type] = key;
    }
  }
}