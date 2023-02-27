import { VehicleMakeStore } from "./VehicleMakeStore";
import { VehicleModelStore } from "./VehicleModelStore";
import { APIService } from "../services/APIService";

const vehicleMakeService = new APIService("https://localhost:7055/api/VehicleMake");
const vehicleModelService = new APIService("https://localhost:7055/api/VehicleModel")

export class RootStore {
  constructor() {
   this.vehicleMakeStore = new VehicleMakeStore(vehicleMakeService);
   this.vehicleModelStore = new VehicleModelStore(vehicleModelService);
  }
}
