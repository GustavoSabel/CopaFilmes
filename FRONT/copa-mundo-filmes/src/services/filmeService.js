import Axios from 'axios'

const ROOT_URL = `http://localhost:5000/api`;

const FilmeService = {
    async ObterTodos() {
        let result = (await Axios.get(ROOT_URL + '/filme')).data;
        return result;
    },
}

export default FilmeService;