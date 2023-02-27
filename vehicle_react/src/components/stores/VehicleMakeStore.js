import { makeObservable, observable, action } from "mobx";


class VehicleMakeStore {
  vehicleMakeService;
  constructor(vehicleMakeService) {
    this.vehicleMakeService = vehicleMakeService;

    makeObservable(this, {
      makes: observable,
      getVehicleMakesAsync: action,
    });
  }
  makes = [];

  getVehicleMakesAsync = async () => {
    try {
      const { data } = await this.vehicleMakeService.get();
    this.makes = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  deleteVehicleMakeAsync = async (id) => {
    try {
      await this.vehicleMakeService.delete(id);
    } catch (error) {
      console.log(error);
    }
  };

}

export { VehicleMakeStore };