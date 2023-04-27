import { CssBaseline, Container, Button } from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import vinylsPng from "../assets/vinyls.png";
import React from "react";

export const AppHome = () => {
  const location = useLocation();
  const path = location.pathname;

  return (
    <React.Fragment>
      <CssBaseline />

      <Container
        maxWidth=""
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          backgroundColor: "#250001",
          padding: "5em",
          height: "100vh",
        }}
      >
        <img src={vinylsPng}></img>
        <Button
          variant={path.startsWith("/vinyls") ? "outlined" : "text"}
          to="/vinyls"
          component={Link}
          sx={{
            backgroundColor: "black",
            color: "#d2c4b4",
            borderRadius: "30px",
            width: "12%",
            height: "3.7em",
            "&:hover": {
              color: "black",
              backgroundColor: "#d2c4b4",
            },
          }}
        >
          See Our Stock
        </Button>
      </Container>
    </React.Fragment>
  );
};
