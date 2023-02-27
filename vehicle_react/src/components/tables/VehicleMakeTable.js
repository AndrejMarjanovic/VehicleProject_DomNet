import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button } from "react-bootstrap";

const VehicleMakeTable = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleMakeStore.getVehicleMakesAsync();
  }, [])

  const deleteVehicleMake = (Id, Name) => {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleMakeStore.deleteVehicleMakeAsync(Id).then(() => rootStore.vehicleMakeStore.getVehicleMakesAsync());
    }
  }

  return (
    <div>
      <Table>
        <thead>
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

