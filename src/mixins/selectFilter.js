const selectFilter = {
  methods: {
    filterOptions: function (input, option) {
      return (
        option.componentOptions.children[0].text
          .toLowerCase()
          .indexOf(input.toLowerCase()) >= 0
      );
    }
  }
};

export default selectFilter;