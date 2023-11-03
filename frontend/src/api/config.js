import axios from 'axios';

export const performRequest = async (url, method = 'get', data = null, token = null) => {
  try {
    const baseURL = 'https://localhost:7071/api/'

    const config = {
      url: baseURL + url,
      method,
      headers: { 'Content-Type': 'application/json' }
    };

    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }

    if (data) {
      config.data = data;
    }

    var response = await axios(config);

    return response.data;
  } catch (error) {
    console.error(error);
  }
};