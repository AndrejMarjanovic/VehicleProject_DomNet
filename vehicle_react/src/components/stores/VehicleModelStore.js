import { makeObservable, observable, action } from "mobx";


class VehicleModelStore {
  vehicleModelService;
  constructor(vehicleModelService) {
    this.vehicleModelService = vehicleModelService;

    makeObservable(this, {
      model: observable,
      models: observable,
      search: observable,
      sortBy: observable,
      isDesc: observable,
      getFilteredVehicleModelsAsync: action,
    });
  }
  model = {};
  models = [];
  search = "";
  sortBy = "";
  isDesc = false;

  getVehicleModelsAsync = async () => {
    try {
      const { data } = await this.vehicleModelService.get();
    this.models = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getFilteredVehicleModelsAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
    };
    try {
      const { data } = await this.vehicleModelService.getFiltered(params);
    this.models = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehicleModelById = async (Id) => {
    try {
      const { data } = await this.vehicleModelService.getById(Id);
      this.model = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  postVehicleModelAsync = async (model) => {
    try {
      const response = await this.vehicleModelService.post(model);
      if (response.status === 201) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  putVehicleModelAsync = async (id, x) => {
    try {
      const response = await this.vehicleModelService.put(id, x);
      if (response.status === 200) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  deleteVehicleModelAsync = async (id) => {
    try {
      await this.vehicleModelService.delete(id);
    } catch (error) {
      console.log(error);
    }
  };

  sortVehicleModelsBy = async (radio, check) => {
    this.sortBy = radio;
    this.isDesc = check;
    await this.getFilteredVehicleModelsAsync();
  };

  searchVehicleModels = async (search) => {
    this.search = search;
    await this.getFilteredVehicleModelsAsync();
  };

  setModelAtributes = async (e) => {
    this.model = { ...this.model, [e.target.name]: e.target.value };
  }

}

export { VehicleModelStore };