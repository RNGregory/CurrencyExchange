<template>
  <div>
    <p>{{ exchangeRate }}</p>
  </div>
</template>

<script>
export default {
  props: {
    exchangeRate: String
  }
};
</script>
