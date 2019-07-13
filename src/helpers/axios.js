import axios from 'axios';


const instance= axios.create({
    baseURL:""
})
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';   

export default instance;