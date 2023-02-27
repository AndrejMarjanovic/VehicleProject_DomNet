import { makeObservable, observable, action } from "mobx";


class VehicleModelStore {
  vehicleModelService;
  constructor(vehicleModelService) {
    this.vehicleModelService = vehicleModelService;

    makeObservable(this, {
      models: observable,
      sortBy: observable,
      isDesc: observable,
      getFilteredVehicleModelsAsync: action,
    });
  }
  models = [];
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
    };
    try {
      const { data } = await this.vehicleModelService.getFiltered(params);
    this.models = [...data];
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

}

export { VehicleModelStore };