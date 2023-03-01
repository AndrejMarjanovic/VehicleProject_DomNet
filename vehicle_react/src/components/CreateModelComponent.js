import { useState } from 'react';
import { inject, observer } from "mobx-react";
import { Button, Row, Form } from "react-bootstrap";
import React, { useEffect } from 'react'

const CreateModelComponent = ({ rootStore }) => {
  useEffect(() => {
    rootStore.vehicleMakeStore.getVehicleMakesAsync();
  }, [])

  var makes = rootStore.vehicleMakeStore.makes;

  const [name, setName] = useState("");
  const [abrv, setAbrv] = useState("");
  const [id, setId] = useState();

  const AddVehicleModel = async (event) => {
    event.preventDefault();
    let model = { name: name, abrv: abrv, vehicleMakeId: id };
    console.log(model);
    if (await rootStore.vehicleModelStore.postVehicleModelAsync(model)) 
    {
      window.alert("You added a new Vehicle Model!").then(() => rootStore.vehicleModelStore.getFilteredVehicleModelsAsync());
    }
    else
    {
      window.alert("Failed to add new Vehicle Model!\nMake sure to select Vehicle Make.");
    }
  };

  return (
    <div className="container" class="col-md-5">
      <strong style={{ display: 'flex', justifyContent: 'left' }}>Create a new "vehicle model" here:</strong>
      <Row>
        <Form onSubmit={AddVehicleModel}>
          <Form.Group controlId="Name">
            <Form.Control
              value={name}
              onChange={(e) => setName(e.target.value)}
              type="text"
              required
              placeholder="Name"
              name="name"
            />
          </Form.Group>
          <br />
          <Form.Group controlId="Abreviation">
            <Form.Control
              value={abrv}
              onChange={(e) => setAbrv(e.target.value)}
              type="text"
              required
              placeholder="Abreviation"
              name="abrv"
            />
          </Form.Group>
          <Form.Group controlId="Id">
          <br />
            <Form.Control as="select"  type="select" className="select" required onChange={(e) => setId(e.target.value)}>
              {makes.map((x) => (<option key={x.id} value={x.id}> {x.name} </option>))}
              <option selected hidden>Select a Make</option>
            </Form.Control>
          </Form.Group>
          <Form.Group>
            <br />
            <Button variant="primary" type="submit" style={{ display: 'flex', justifyContent: 'left' }}>
              Post Make
            </Button>
          </Form.Group>
        </Form>
      </Row>
    </div>
  )
}

export default inject("rootStore")(observer(CreateModelComponent));