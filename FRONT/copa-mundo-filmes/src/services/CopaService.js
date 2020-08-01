import Axios from 'axios'

const CopaService = {
    async Disputar(filmes) {
        let result = (await Axios.post('/api/copa/disputar', filmes)).data;
        return result;
    },
}

export default CopaService;