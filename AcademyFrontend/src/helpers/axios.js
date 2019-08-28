import axios from 'axios';


const instance= axios.create({
    baseURL:""
})
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';   
axios.defaults.headers.common['Content-Type']='application/json';
export default instance;