import axios from "axios";

class APIService {
  url;
  constructor(url) {
    this.url = url;
  }

  get = () => {
    return axios.get(this.url);
  };

  getFiltered = (filters) => {
    return axios.get(this.url + "/Filtered", {
      params: {...filters},
    });
  };

  getById = (Id) => {
    return axios.get(this.url + "/" + Id);
  };

  post = (object) => {
    try {
      return axios.post(this.url, object);
    } catch (error) {
      console.log(error);
    }
  };

  put(id, object) {
    try {
    return axios.put(this.url + "/" + id, object);
    } catch(error){
      console.log(error);
    }
  }

  delete = (id) => {
    return axios.delete(this.url + "/" + id);
  };
}

export { APIService };