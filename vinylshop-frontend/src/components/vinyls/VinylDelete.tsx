import {
  Container,
  Card,
  CardContent,
  IconButton,
  CardActions,
  Button,
  Typography,
} from "@mui/material";
import { Link, useNavigate, useParams } from "react-router-dom";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import HighlightOffRoundedIcon from "@mui/icons-material/HighlightOffRounded";
import axios from "axios";
import { BACKEND_API_URL } from "../../constants";
import React from "react";

export const VinylDelete = () => {
  const { vinylId } = useParams();
  const navigate = useNavigate();

  const handleDelete = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    await axios.delete(`${BACKEND_API_URL}/vinyls/deleteVinyl/${vinylId}`);
    // go to vinyls list
    navigate("/vinyls");
  };

  const handleCancel = (event: { preventDefault: () => void }) => {
    event.preventDefault();
    // go to vinyls list
    navigate("/vinyls");
  };

  return (
    <Container
      sx={{
        display: "flex",
        justifyContent: "center",
        padding: "15em",
        maxWidth: "100em!important",
      }}
    >
      <Card>
        <CardContent>
          <IconButton component={Link} to={`/vinyls`}>
            <HighlightOffRoundedIcon fontSize="large" />
          </IconButton>
        </CardContent>

        <Card sx={{ padding: 6 }}>
          <CardContent>
            <Typography>
              Are you sure you want to delete this vinyl?This cannot be undone!
            </Typography>
          </CardContent>
          <CardActions
            sx={{
              display: "flex",
              justifyContent: "space-evenly",
              paddingTop: 3,
            }}
          >
            <Button
              sx={{
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "30%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
              onClick={handleDelete}
            >
              Delete it
            </Button>
            <Button
              sx={{
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "30%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
              onClick={handleCancel}
            >
              Cancel
            </Button>
          </CardActions>
        </Card>
      </Card>
    </Container>
  );
};
