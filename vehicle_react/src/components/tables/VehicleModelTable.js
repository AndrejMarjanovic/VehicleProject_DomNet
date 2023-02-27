import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button } from "react-bootstrap";

const VehicleModelTable = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleModelStore.getVehicleModelsAsync();
  }, [])

  const deleteVehicleModel = (Id, Name) => {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleModelStore.deleteVehicleModelAsync(Id).then(() => rootStore.vehicleModelStore.getVehicleModelsAsync());
    }
  }

  return (
    <div>
      <Table>
        <thead>
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