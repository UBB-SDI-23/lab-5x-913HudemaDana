import {
  Box,
  AppBar,
  Toolbar,
  IconButton,
  Typography,
  Button,
} from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import AlbumIcon from "@mui/icons-material/Album";
import LocalLibraryIcon from "@mui/icons-material/LocalLibrary";
import React from "react";
import { Container } from "react-bootstrap";

export const AppMenu = () => {
  const location = useLocation();
  const path = location.pathname;

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" sx={{ backgroundColor: "white" }}>
        <Toolbar sx={{ display: "flex", justifyContent: "center" }}>
          <Button
            disableRipple
            to="/albums"
            component={Link}
            color="inherit"
            sx={{
              mr: 2,
              color: "black",
              "&:hover": {
                color: "black",
                backgroundColor: "#d2c4b4",
              },
            }}
          >
            Albums
          </Button>
          <Button
            disableRipple
            to="/vinyls"
            component={Link}
            color="inherit"
            sx={{
              mr: 2,
              color: "black",
              "&:hover": {
                color: "black",
                backgroundColor: "#d2c4b4",
              },
            }}
          >
            Vinyls
          </Button>

          <IconButton
            disableRipple
            component={Link}
            to="/"
            size="large"
            edge="start"
            color="inherit"
            aria-label="vinyl"
            sx={{
              mr: 2,
              ml: 2,
              "&:hover": {
                textDecorationLine: "none",
              },
            }}
          >
            <Typography variant="h4" component="div" sx={{ color: "	black" }}>
              VINYL SH
              <AlbumIcon fontSize="medium" />P
            </Typography>
          </IconButton>

          <Button
            disableRipple
            to="/vinyls/add"
            component={Link}
            color="inherit"
            sx={{
              ml: 2,
              color: "black",
              "&:hover": {
                color: "black",
                backgroundColor: "#d2c4b4",
              },
            }}
          >
            Add Vinyl
          </Button>
        </Toolbar>
        <Container sx={{ backgroundColor: "white" }}></Container>
      </AppBar>
    </Box>
  );
};
