import React, { useEffect, useState } from 'react'
import { observer, inject } from "mobx-react";
import { Table, Button, Modal, Form, Row } from "react-bootstrap";
import CreateMakeComponent from "../components/CreateMakeComponent";
import VehicleMakePaging from "../components/VehicleMakePaging";

const VehicleMake = ({ rootStore }) => {
  useEffect(() => {
    getData();
  }, [])

  const getData = () => {
    rootStore.vehicleMakeStore.getFilteredVehicleMakesAsync();
  };

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  function sortBy(radioBtn) {
    var checkBox = document.getElementById("isDesc");
    rootStore.vehicleMakeStore.sortVehicleMakesBy(radioBtn, checkBox.checked);

  };

  function handleSearchChange(event) {
    rootStore.vehicleMakeStore.searchVehicleMakes(event.target.value)
  };

  function ConfirmDelete(Id, Name) {
    if (window.confirm("Are you sre you want to permanently delete " + Name + "?")) {
      rootStore.vehicleMakeStore.deleteVehicleMakeAsync(Id).then(() => getData());
    }
  }

  function OpenEditModal(id) {
    rootStore.vehicleMakeStore.getVehicleMakeById(id);
    handleShow();
  }

  const EditVehicleMake = async (event) => {
    event.preventDefault();
    try {
      const id = rootStore.vehicleMakeStore.make.id;
      const make = {
        name: rootStore.vehicleMakeStore.make.name,
        abrv: rootStore.vehicleMakeStore.make.abrv
      };
      await rootStore.vehicleMakeStore.putVehicleMakeAsync(id, make)
        .then(() => getData());
      handleClose();
    }
    catch (error) {
      console.log(error);
      window.alert("Failed to edit vehicle make");
    }
  };

  return (
    <div>
      <br />
      <div class="col-md-5">
        <form className="d-flex" >
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
              <input
                type="radio"
                id="byAbb"
                name="SortBy"
                value="abrv"
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
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {rootStore.vehicleMakeStore.makes.map(x => (
            <tr key={x.id}>
              <td>{x.name}</td>
              <td>{x.abrv}</td>
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

      <div className="createMake">
        <br />
        <VehicleMakePaging />
      </div>

      <div className="createMake">
        <br />
        <CreateMakeComponent />
      </div>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Edit selected 'vehicle make'</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Row>
            <Form onSubmit={EditVehicleMake}>
              <Form.Group controlId="Name">
                <Form.Control
                  value={rootStore.vehicleMakeStore.make.name}
                  onChange={(e) => rootStore.vehicleMakeStore.setMakeAtributes(e)}
                  type="text"
                  required
                  placeholder={rootStore.vehicleMakeStore.make.name}
                  name="name"
                />
              </Form.Group>
              <br />
              <Form.Group controlId="Abreviation">
                <Form.Control
                  value={rootStore.vehicleMakeStore.make.abrv}
                  onChange={(e) => rootStore.vehicleMakeStore.setMakeAtributes(e)}
                  type="text"
                  required
                  placeholder={rootStore.vehicleMakeStore.make.abrv}
                  name="abrv"
                />
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

export default inject("rootStore")(observer(VehicleMake));