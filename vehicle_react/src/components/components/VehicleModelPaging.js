import { Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";

const VehicleModelPaging = ({ rootStore }) => {

   const changePage = (x) => {
      rootStore.vehicleModelStore.setPageNumber(rootStore.vehicleModelStore.page + x);
   };

   const jumpToPage = (x) => {
      rootStore.vehicleModelStore.setPageNumber(x);
   }

   return (
      <div className="container">
         <Button className="page-button-prev" onClick={() => changePage(-1)} disabled={rootStore.vehicleModelStore.page === 1}>&lt; Prev</Button>
         <Button variant="secondary" onClick={() => jumpToPage(1)} disabled={rootStore.vehicleModelStore.page === 1}> 1 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(2)} disabled={rootStore.vehicleModelStore.page === 2}> 2 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(3)} disabled={rootStore.vehicleModelStore.page === 3}> 3 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(4)} disabled={rootStore.vehicleModelStore.page === 4}> 4 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(5)} disabled={rootStore.vehicleModelStore.page === 5}> 5 </Button>
         <strong className="page-text"> Page: {rootStore.vehicleModelStore.page} / 10 </strong>
         <Button variant="secondary" onClick={() => jumpToPage(10)} disabled={rootStore.vehicleModelStore.page === 10}> 10 </Button>
         <Button className="page-button-next" onClick={() => changePage(1)} disabled={rootStore.vehicleModelStore.page === 10}>Next &gt;</Button>
      </div>
   );
}

export default inject("rootStore")(observer(VehicleModelPaging));