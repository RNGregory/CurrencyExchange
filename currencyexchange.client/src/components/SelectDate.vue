<template>
  <div>
    <label for="date">Select Date:  </label>
    <input type="date" v-model="selectedDate" @change="updateDate">
  </div>
</template>

<script>
export default {
  props: {
    modelValue: String
  },
  data() {
    return {
      selectedDate: this.modelValue
    };
  },
  methods: {
    updateDate() {
      this.$emit('update:date', this.selectedDate);
    }
  }
};
</script>
