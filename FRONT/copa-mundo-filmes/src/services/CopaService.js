import api from './Api';

const CopaService = {
  async Disputar(filmes) {
      let result = (await api.post('/api/copa/disputar', filmes)).data;
      return result;
  },
}

export default CopaService;