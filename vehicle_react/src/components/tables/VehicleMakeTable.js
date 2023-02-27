import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button } from "react-bootstrap";

const VehicleMakeTable = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleMakeStore.getFilteredVehicleMakesAsync();
  }, [])

  function sortBy(radio, checkDesc) {
    var checkBox = document.getElementById("isDesc");
    var checkDesc;

    if (checkBox.checked == true) {
      checkDesc = true;
    } else {
      checkDesc = false;
    }
    rootStore.vehicleMakeStore.sortVehicleMakesBy(radio, checkDesc);

  };

  function deleteVehicleMake(Id, Name) {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleMakeStore.deleteVehicleMakeAsync(Id).then(() => rootStore.vehicleMakeStore.getFilteredVehicleMakesAsync());
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
              <input
                type="radio"
                id="byAbb"
                name="SortBy"
                value="abrv"
                onClick={() => sortBy("abrv")} />
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
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {rootStore.vehicleMakeStore.makes.map(x => (
            <tr key={x.id}>
              <td>{x.name}</td>
              <td>{x.abrv}</td>
              <td>
                <Button
                  variant="danger"
                  onClick={() => deleteVehicleMake(x.id, x.name)}
                >X</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )
}

export default inject("rootStore")(observer(VehicleMakeTable));

