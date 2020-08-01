import Axios from 'axios'

const FilmeService = {
    async ObterTodos() {
        let result = (await Axios.get('/api/filme')).data;
        return result;
    },
}

export default FilmeService;