<template>
  <div>
    <button @click="convert">Convert</button>
  </div>
</template>

<script>
export default {
  methods: {
    convert() {
      this.$emit('convert');
    }
  }
};
</script>
