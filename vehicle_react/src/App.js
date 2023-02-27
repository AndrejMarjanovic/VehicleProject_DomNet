import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Navbar, Nav } from "react-bootstrap";
import VehicleMake from "./components/pages/VehicleMake";
import VehicleModel from "./components/pages/VehicleModel";
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <div className = "container">
          <Navbar className="navbar navbar-expand-lg" bg="light">
            <Nav className="nav">
              <Nav.Link href="/vehiclemake">Vehicle make</Nav.Link>
              <Nav.Link href="/vehiclemodel">Vehicle model</Nav.Link>
            </Nav>
          </Navbar>
          <Routes>
            <Route path="/vehiclemake" element={<VehicleMake />} />
            <Route path="/vehiclemodel" element={<VehicleModel />} />
          </Routes>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
