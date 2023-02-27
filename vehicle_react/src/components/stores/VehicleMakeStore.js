import { makeObservable, observable, action } from "mobx";


class VehicleMakeStore {
  vehicleMakeService;
  constructor(vehicleMakeService) {
    this.vehicleMakeService = vehicleMakeService;

    makeObservable(this, {
      makes: observable,
      sortBy: observable,
      isDesc: observable,
      search: observable,
      getFilteredVehicleMakesAsync: action,
    });
  }
  makes = [];
  search = "";
  sortBy = "";
  isDesc = false;

  getFilteredVehicleMakesAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
    };
    try {
      const { data } = await this.vehicleMakeService.getFiltered(params);
    this.makes = [...data];
    } catch (error) {
      console.log(error);
    }
  };

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

  sortVehicleMakesBy = async (radio, check) => {
    this.sortBy = radio;
    this.isDesc = check;
    await this.getFilteredVehicleMakesAsync();
  };

  searchVehicleMakes = async (search) => {
    this.search = search;
    await this.getFilteredVehicleMakesAsync();
  };

}

export { VehicleMakeStore };