import axios from 'axios';

export function loginUser(user) {
  const { email, password} = user;
  return axios.post('/api/accounts/login', {
    email,
    password
  })
}

export function registerUser(user) {
  const { email, passsword, userName } = user;
  return axios.post('/api/accounts/register', {
    email,
    password,
    userName
  })
}
