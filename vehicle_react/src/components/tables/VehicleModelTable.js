import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button } from "react-bootstrap";

const VehicleModelTable = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleModelStore.getFilteredVehicleModelsAsync();
  }, [])

  function sortBy(radio, checkDesc) {
    var checkBox = document.getElementById("isDesc");
    var checkDesc;

    if (checkBox.checked == true) {
      checkDesc = true;
    } else {
      checkDesc = false;
    }
    rootStore.vehicleModelStore.sortVehicleModelsBy(radio, checkDesc);

  };
  
  const deleteVehicleModel = (Id, Name) => {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleModelStore.deleteVehicleModelAsync(Id).then(() => rootStore.vehicleModelStore.getFilteredVehicleModelsAsync());
    }
  }

  return (
    <div>
      <Table>
        <thead>
        <tr>
            <th>
            <input
                type="radio"
                id="ByName"
                name="SortBy"
                value="name" 
                onClick={() => sortBy("name")} />
              <label>Sort</label>
            </th>
            <th>
           
            </th>
            <th>
            <input
                type="radio"
                id="byMake"
                name="SortBy"
                value="make" 
                onClick={() => sortBy("make")} />
              <label>Sort</label>
            </th>
            <th>
              <input
                type="checkbox"
                id="isDesc"
                name="isDesc" />
              <label>Descending</label>
            </th>
          </tr>
          <tr>
            <th>Name</th>
            <th>Abbreviation</th>
            <th>Vehicle Make</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {rootStore.vehicleModelStore.models.map(x => (
            <tr key={x.id}>
              <td>{x.name}</td>
              <td>{x.abrv}</td>
              <td>{x.vehicleMake.name}</td>
              <td>
                <Button variant="danger" onClick={() => deleteVehicleModel(x.id, x.name)}>X</Button>
                </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )
}

export default inject("rootStore")(observer(VehicleModelTable));