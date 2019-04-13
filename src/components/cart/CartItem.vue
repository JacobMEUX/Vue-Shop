<template>
  <a-card>
  <a-card-meta
    :title="item.title"
    :description="item.description">
    <a-avatar slot="avatar" :src="item.image.url" />
  </a-card-meta>
</a-card>
</template>

<script>
export default {
  props: {
      item: Object
  }
};
</script>
