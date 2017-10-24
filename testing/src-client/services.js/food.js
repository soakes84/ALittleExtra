import axios from 'axios';

export function addFood(foodData) {
  return axios.post('/api/totalfood', foodData)
}

export function getAllFood() {
  return axios.get('/api/totalfood')
}
