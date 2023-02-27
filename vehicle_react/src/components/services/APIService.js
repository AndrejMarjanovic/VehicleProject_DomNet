import axios from "axios";

class APIService {
  url;
  constructor(url) {
    this.url = url;
  }

  get = () => {
    return axios.get(this.url);
  };
  getById = (Id) => {
    return axios.get(this.url + "/" + Id);
  };
  post = (object) => {
    return axios.post(this.url, object);
  };
  edit(id, object) {
    return axios.put(this.url + "/" + id, object);
  }
  delete = (id) => {
    return axios.delete(this.url + "/" + id);
  };
}

export { APIService };