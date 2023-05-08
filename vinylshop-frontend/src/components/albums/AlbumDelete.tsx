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

export const AlbumDelete = () => {
  const { albumId } = useParams();
  const navigate = useNavigate();

  const handleDelete = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    await axios.delete(`${BACKEND_API_URL}/albums/deleteAlbum/${albumId}`);
    // go to albums list
    navigate("/albums");
  };

  const handleCancel = (event: { preventDefault: () => void }) => {
    event.preventDefault();
    // go to albums list
    navigate("/albums");
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
          <IconButton component={Link} to={`/albums`}>
            <HighlightOffRoundedIcon fontSize="large" />
          </IconButton>
        </CardContent>

        <Card sx={{ padding: 6 }}>
          <CardContent>
            <Typography>
              Are you sure you want to delete this album?This cannot be undone!
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
