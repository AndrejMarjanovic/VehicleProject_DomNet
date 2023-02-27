import { observer, inject } from "mobx-react";
import VehicleMakeTable from "../tables/VehicleMakeTable";

const VehicleMake = () => {

  return (<div className="container">
    <VehicleMakeTable />
  </div>);
}
export default inject("rootStore")(observer(VehicleMake));
