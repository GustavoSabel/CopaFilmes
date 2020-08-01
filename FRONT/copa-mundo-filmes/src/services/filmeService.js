import api from './Api';

const FilmeService = {
    async ObterTodos() {
        let result = (await api.get('/api/filme')).data;
        return result;
    },
}

export default FilmeService;