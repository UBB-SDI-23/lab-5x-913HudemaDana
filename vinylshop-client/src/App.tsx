import { useState } from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import * as React from "react";
import { AppBar, Toolbar, IconButton, Typography, Button } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
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
			<Router>
				<AppMenu />

				<Routes>
					<Route path="/" element={<AppHome />} />
					<Route path="/vinyls" element={<AllVinyls />} />
					<Route path="/vinyls/:vinylId/details" element={<VinylDetails />} />
					<Route path="/vinyls/:vinylId/edit" element={<VinylDetails />} />
					<Route path="/vinyls/:vinylId/delete" element={<VinylDelete />} />
					<Route path="/vinyls/add" element={<VinylAdd />} />
				</Routes>
			</Router>
		</React.Fragment>
	);
}

export default App;