import { makeObservable, observable, action } from "mobx";


class VehicleModelStore {
  vehicleModelService;
  constructor(vehicleModelService) {
    this.vehicleModelService = vehicleModelService;

    makeObservable(this, {
      models: observable,
      getVehicleModelsAsync: action,
    });
  }
  models = [];

  getVehicleModelsAsync = async () => {
    try {
      const { data } = await this.vehicleModelService.get();
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

}

export { VehicleModelStore };