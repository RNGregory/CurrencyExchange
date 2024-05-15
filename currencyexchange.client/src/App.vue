<template>
  <div>
    <SelectCurrency v-model="selectedCurrency" @update:currency="updateCurrency" />
    <SelectDate v-model="selectedDate" @update:date="updateDate" />
    <ConvertButton @convert="getConversion" />
    <ConvertResult :exchangeRate="exchangeRate" />
  </div>
</template>


<script>
import axios from 'axios';
import SelectCurrency from './components/SelectCurrency.vue';
import SelectDate from './components/SelectDate.vue';
import ConvertButton from './components/ConvertButton.vue';
import ConvertResult from './components/ConvertResult.vue';

export default {
  components: {
    SelectCurrency,
    SelectDate,
    ConvertButton,
    ConvertResult
  },
  data() {
    return {
      selectedCurrency: null,
      selectedDate: null,
      exchangeRate: null,
      preparedDate: '06.06.2023', //prepared var's for testing purposes only
      preparedCurrency: 'EUR'
    };
  },
  computed: {
    formattedDate() {
      if (this.selectedDate) {
        const [year, month, day] = this.selectedDate.split('-');
        return `${day}.${month}.${year}`;
      }
      return null;
    }
  },
  methods: {
    async getConversion() {
      try {
        const response = await axios.post(`/exchange?date=${this.preparedDate}&currency=${this.preparedCurrency}`);
        this.exchangeRate = response.data;
      } catch (err) {
        console.error("There was an error fetching exchange rate:", err);
      }
    },
    updateCurrency(currency) {
      this.selectedCurrency = currency;
    },
    updateDate(date) {
      this.selectedDate = date;
    }
  }
};
</script>

<style>
.welcome {
    font-size: 24px;
    font-family: "Arial";
    color: #333;
}
</style>
