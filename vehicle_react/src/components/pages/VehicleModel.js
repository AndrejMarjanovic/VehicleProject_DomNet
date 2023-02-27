import { observer, inject } from "mobx-react";
import VehicleModelTable from "../tables/VehicleModelTable";

const VehicleModel = () => {

  return (<div className="container">
    <VehicleModelTable />
  </div>);
}
export default inject("rootStore")(observer(VehicleModel));
