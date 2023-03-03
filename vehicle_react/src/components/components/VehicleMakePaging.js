import { Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";

const VehicleMakePaging = ({ rootStore }) => {

   const changePage = (x) => {
      rootStore.vehicleMakeStore.setPageNumber(rootStore.vehicleMakeStore.page + x);
   };

   const jumpToPage = (x) => {
      rootStore.vehicleMakeStore.setPageNumber(x);
   };

   return (
      <div className="container">
         <Button className="page-button-prev" onClick={() => changePage(-1)} disabled={rootStore.vehicleMakeStore.page === 1}>&lt; Prev</Button>
         <Button variant="secondary" onClick={() => jumpToPage(1)} disabled={rootStore.vehicleMakeStore.page === 1}> 1 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(2)} disabled={rootStore.vehicleMakeStore.page === 2}> 2 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(3)} disabled={rootStore.vehicleMakeStore.page === 3}> 3 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(4)} disabled={rootStore.vehicleMakeStore.page === 4}> 4 </Button>
         <Button variant="secondary" onClick={() => jumpToPage(5)} disabled={rootStore.vehicleMakeStore.page === 5}> 5 </Button>
         <strong className="page-text"> Page: {rootStore.vehicleMakeStore.page} / 5 </strong>
         <Button className="page-button-next" onClick={() => changePage(1)} disabled={rootStore.vehicleMakeStore.page === 5}>Next &gt;</Button>
      </div>
   );
}

export default inject("rootStore")(observer(VehicleMakePaging));