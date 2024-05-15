<template>
  <div>
    <label class="welcome">Welcome to Currency Exchange</label>
  </div>
  <div>
    <label for="date">Select Currency:  </label>
    <select v-model="selectedCurrency" @change="updateCurrency">
      <option value="USD"> US Dollar </option>
      <option value="EUR"> Euro </option>
      <option value="GBP"> British Pound </option>
      <option value="PLN"> Polish Zloty </option>
    </select>
  </div>
</template>

<script>
export default {
  props: {
    modelValue: String 
  },
    data() {
    return {
      selectedCurrency: this.modelValue
    };
  },
  methods: {
    updateCurrency() {
      this.$emit('update:currency', this.selectedCurrency);
    }
  }
};
</script>
