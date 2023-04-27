import * as React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AppHome } from "./components/AppHome";
import { AppMenu } from "./components/AppMenu";
import { AllVinyls } from "./components/vinyls/AllVinyls";
import { VinylDetails } from "./components/vinyls/VinylDetails";
import { VinylDelete } from "./components/vinyls/VinylDelete";
import { VinylAdd } from "./components/vinyls/VinylAdd";

function App() {
  return (
    <React.Fragment>
      <AppMenu />

      <Routes>
        <Route path="/" element={<AppHome />} />
        <Route path="/vinyls" element={<AllVinyls />} />
        <Route path="/vinyls/:vinylId/details" element={<VinylDetails />} />
        <Route path="/vinyls/:vinylId/edit" element={<VinylDetails />} />
        <Route path="/vinyls/:vinylId/delete" element={<VinylDelete />} />
        <Route path="/vinyls/add" element={<VinylAdd />} />
      </Routes>
    </React.Fragment>
  );
}

export default App;