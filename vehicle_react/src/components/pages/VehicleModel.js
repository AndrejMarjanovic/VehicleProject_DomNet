import React, { useEffect, useState } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button, Modal, Form, Row } from "react-bootstrap";
import CreateModelComponent from "../components/CreateModelComponent";

const VehicleModel = ({ rootStore }) => {
  useEffect(() => {
    getData();
  }, [])

  const getData = () => {
    rootStore.vehicleModelStore.getFilteredVehicleModelsAsync();
  }

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  function sortBy(radioBtn) {
    var checkBox = document.getElementById("isDesc");
    rootStore.vehicleModelStore.sortVehicleModelsBy(radioBtn, checkBox.checked);

  };

  function ConfirmDelete(Id, Name) {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleModelStore.deleteVehicleModelAsync(Id).then(() => getData());
    }
  }

  const handleSearchChange = (event) => {
    rootStore.vehicleModelStore.searchVehicleModels(event.target.value);
  };

  function OpenEditModal(id) {
    rootStore.vehicleModelStore.getVehicleModelById(id);
    handleShow();
  }

  const EditVehicleModel = async (event) => {
    event.preventDefault();
    try {
      const id = rootStore.vehicleModelStore.model.id;
      const model = {
        name: rootStore.vehicleModelStore.model.name,
        abrv: rootStore.vehicleModelStore.model.abrv,
        vehicleMakeId: rootStore.vehicleModelStore.model.vehicleMakeId
      };
      console.log(model);
      await rootStore.vehicleModelStore.putVehicleModelAsync(id, model)
        .then(() => getData());
      handleClose();
    }
    catch (error) {
      console.log(error);
      window.alert("Failed to edit vehicle model");
    }
  };


  return (
    <div>
      <br />
      <div class="col-md-5">
        <form className='d-flex'>
          <input type="search" class="form-control" id="search" name="search"
            placeholder="Search by one of the atributes"
            onChange={handleSearchChange} />
        </form>
      </div>
      <br />
      <Table>
        <thead>
          <tr>
            <th>
              <input
                type="radio"
                id="ByName"
                name="SortBy"
                value="name"
                onClick={(e) => sortBy(e.target.value)} />
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
                onClick={(e) => sortBy(e.target.value)} />
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
                <Button variant="primary" onClick={() => OpenEditModal(x.id)} >
                  Edit</Button>
                <Button variant="danger" onClick={() => ConfirmDelete(x.id, x.name)}>
                  Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      <div>
        <br />
        <CreateModelComponent />
      </div>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Edit selected 'vehicle model'</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Row>
            <Form onSubmit={EditVehicleModel}>
              <Form.Group controlId="Name">
                <Form.Control
                  value={rootStore.vehicleModelStore.model.name}
                  onChange={(e) => rootStore.vehicleModelStore.setModelAtributes(e)}
                  type="text"
                  required
                  placeholder={rootStore.vehicleModelStore.model.name}
                  name="name"
                />
              </Form.Group>
              <br />
              <Form.Group controlId="Abreviation">
                <Form.Control
                  value={rootStore.vehicleModelStore.model.abrv}
                  onChange={(e) => rootStore.vehicleModelStore.setModelAtributes(e)}
                  type="text"
                  required
                  placeholder={rootStore.vehicleModelStore.model.abrv}
                  name="abrv"
                />
              </Form.Group>
              <Form.Group controlId="Id">
                <br />
                <Form.Select as="select" type="select" className="select" name="vehicleMakeId"
                  value={rootStore.vehicleModelStore.model.vehicleMakeId} required 
                  onChange={(e) => rootStore.vehicleModelStore.setModelAtributes(e)}>
                  {rootStore.vehicleMakeStore.makes.map((x) => (<option key={x.id} value={x.id}> {x.name} </option>))}
                </Form.Select>
              </Form.Group>
              <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                  Close
                </Button>
                <Button variant="primary" type="submit" >
                  Save Changes
                </Button>
              </Modal.Footer>
            </Form>
          </Row>
        </Modal.Body>
      </Modal>
    </div>
  )
}

export default inject("rootStore")(observer(VehicleModel));