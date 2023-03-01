import { useState } from 'react';
import { inject, observer } from "mobx-react";
import { Button, Row, Form } from "react-bootstrap";

const CreateMakeComponent = ({ rootStore }) => {

  const [name, setName] = useState("");
  const [abrv, setAbrv] = useState("");
  
  const AddVehicleMake = async (event) => {
    event.preventDefault();
    let make = {name: name, abrv: abrv};
    try {
      await rootStore.vehicleMakeStore.postVehicleMakeAsync(make)
      .then(()=>window.alert("You added a new Vehicle Make!"))
      .then(()=>rootStore.vehicleMakeStore.getFilteredVehicleMakesAsync());
    }
    catch (error) {
      console.log(error);
      window.alert("Failed to add new Vehicle Make");
    }
  };

    return (
      <div className="container" class="col-md-5">
        <strong style={{display: 'flex', justifyContent: 'left'}}>Create a new "vehicle make" here:</strong>
        <Row>
            <Form onSubmit={AddVehicleMake}>
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
              <br/>
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
              <Form.Group>
              <br/>
                <Button variant="primary" type="submit" style={{display: 'flex', justifyContent: 'left'}}>
                  Post Make
                </Button>
              </Form.Group>
            </Form>
        </Row>
      </div>
    )
  }

export default inject("rootStore")(observer(CreateMakeComponent));