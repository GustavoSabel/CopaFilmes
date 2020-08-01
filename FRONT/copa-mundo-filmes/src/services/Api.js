import axios from 'axios';
import { toast } from 'react-toastify';

const api = axios.create({
  baseURL: 'http://localhost:5000',
});
api.interceptors.response.use(
  config => config,
  ex => {
    if (ex && ex.response && ex.response.data && ex.response.data.mensagem) {
      toast.warn(ex.response.data.mensagem);
    }
    else {
      toast.error("Ocorreu um erro");
      console.log(ex.toJSON());
    }
    return Promise.reject(ex);
  });

export default api;