import axios from "axios";

class APIService {
  url;
  constructor(url) {
    this.url = url;
  }

  get = () => {
    return axios.get(this.url);
  };

  getFiltered = (route) => {
    return axios.get(this.url + "/Filtered", {
      params: {...route,},
    });
  };

  getById = (Id) => {
    return axios.get(this.url + "/" + Id);
  };
  post = (object) => {
    return axios.post(this.url, object);
  };

  put(id, object) {
    return axios.put(this.url + "/" + id, object);
  }

  delete = (id) => {
    return axios.delete(this.url + "/" + id);
  };
}

export { APIService };