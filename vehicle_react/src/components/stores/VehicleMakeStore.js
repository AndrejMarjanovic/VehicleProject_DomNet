import { makeObservable, observable, action } from "mobx";


class VehicleMakeStore {
  vehicleMakeService;
  constructor(vehicleMakeService) {
    this.vehicleMakeService = vehicleMakeService;

    makeObservable(this, {
      makes: observable,
      make: observable,
      sortBy: observable,
      isDesc: observable,
      search: observable,
    });
  }
  make = {};
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

  getVehicleMakeById = async (Id) => {
    try {
      const { data } = await this.vehicleMakeService.getById(Id);
      this.make = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  postVehicleMakeAsync = async (make) => {
    try {
      const response = await this.vehicleMakeService.post(make);
      if (response.status === 201) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  putVehicleMakeAsync = async (id, x) => {
    try {
      const response = await this.vehicleMakeService.put(id, x);
      if (response.status === 200) {
        console.log(response);
      }
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

  setMakeAtributes = async (e) => {
    this.make = { ...this.make, [e.target.name]: e.target.value };
  }
}

export { VehicleMakeStore };