import * as React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AppHome } from "./components/AppHome";
import { AppMenu } from "./components/AppMenu";
import { AllVinyls } from "./components/vinyls/AllVinyls";
import { VinylDetails } from "./components/vinyls/VinylDetails";
import { VinylDelete } from "./components/vinyls/VinylDelete";
import { VinylAdd } from "./components/vinyls/VinylAdd";
import { AllAlbums } from "./components/albums/AllAlbums";
import { VinylUpdate } from "./components/vinyls/VinylUpdate";

function App() {
  return (
    <React.Fragment>
      <AppMenu />

      <Routes>
        <Route path="/" element={<AppHome />} />
        <Route path="/vinyls" element={<AllVinyls />} />
        <Route path="/vinyls/:vinylId/details" element={<VinylDetails />} />
        <Route path="/vinyls/:vinylId/edit" element={<VinylUpdate />} />
        <Route path="/vinyls/:vinylId/delete" element={<VinylDelete />} />
        <Route path="/vinyls/add" element={<VinylAdd />} />
        <Route path="/albums" element={<AllAlbums />} />
      </Routes>
    </React.Fragment>
  );
}

export default App;
