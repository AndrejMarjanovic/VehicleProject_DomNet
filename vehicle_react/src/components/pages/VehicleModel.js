import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button } from "react-bootstrap";
import CreateModelComponent from "../CreateModelComponent";

const VehicleModel = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleModelStore.getFilteredVehicleModelsAsync();
  }, [])

  function sortBy(radioBtn) {
    var checkBox = document.getElementById("isDesc");
    rootStore.vehicleModelStore.sortVehicleModelsBy(radioBtn, checkBox.checked);

  };
  
  function ConfirmDelete (Id, Name) {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleModelStore.deleteVehicleModelAsync(Id).then(() => rootStore.vehicleModelStore.getFilteredVehicleModelsAsync());
    }
  }

  const handleChange = (event) => {
    rootStore.vehicleModelStore.searchVehicleModels(event.target.value)
  };

  return (
    <div>
      <br/>
      <div class="col-md-5">
        <form className='d-flex'>
          <input type="search" class="form-control" id="search" name="search" 
          placeholder="Search by one of the atributes" 
          onChange={handleChange}/>
        </form>
      </div>
      <br/>
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
                <Button variant="danger" onClick={() => ConfirmDelete(x.id, x.name)}>
                  Delete</Button>
                </td>
            </tr>
          ))}
        </tbody>
      </Table>
      <div>
       <br />
       <CreateModelComponent/>
      </div>
    </div>
  )
}

export default inject("rootStore")(observer(VehicleModel));