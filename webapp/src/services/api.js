import axios from 'axios';


export default axios.create({
  baseURL: `${process.env.REACT_APP_API_URL}`,
  timeout: 6000,
  headers:{
      'Cache-Control': 'no-cache',
      'Pragma': 'no-cache',
      'Expires': '0'
  }
});
