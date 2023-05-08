import {
  Autocomplete,
  Button,
  Card,
  CardActions,
  CardContent,
  IconButton,
  TextField,
} from "@mui/material";
import DatePicker from "@mui/lab/DatePicker";
import { Container } from "@mui/system";
import { useCallback, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import axios from "axios";
import { debounce, parseInt } from "lodash";
import { Artist } from "../../models/Artist";

export const ArtistAdd = () => {
  const navigate = useNavigate();

  const [artist, setArtist] = useState<Artist>({
    id: 1,
    firstName: "",
    lastName: "",
    age: 20,
    nationality: "",
    activeYears: 3,
    description: "",
  });

  const addArtist = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    try {
      await axios.post(`${BACKEND_API_URL}/artists/addArtist`, artist);
      navigate("/artists");
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Container
      sx={{
        display: "flex",
        justifyContent: "center",
        padding: "5em",
      }}
    >
      <Card>
        <CardContent>
          <IconButton component={Link} sx={{ mr: 3, mb: 3 }} to={`/artists`}>
            <ClearRoundedIcon />
          </IconButton>{" "}
          <form onSubmit={addArtist}>
            <TextField
              id="firstName"
              label="First Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({ ...artist, firstName: event.target.value })
              }
            />
            <TextField
              id="lastName"
              label="Last Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({ ...artist, lastName: event.target.value })
              }
            />
            <TextField
              id="description"
              label="Description"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({ ...artist, description: event.target.value })
              }
            />
            <TextField
              type="number"
              id="age"
              label="Age"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({ ...artist, age: parseInt(event.target.value) })
              }
            />
            <TextField
              id="nationality"
              label="Nationality"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({ ...artist, nationality: event.target.value })
              }
            />
            <TextField
              type="number"
              id="activeYears"
              label="Active Years"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setArtist({
                  ...artist,
                  activeYears: parseInt(event.target.value),
                })
              }
            />
            <Button
              type="submit"
              sx={{
                mt: 3,
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "15%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
            >
              Add Artist
            </Button>

            <Button
              component={Link}
              to={`/artists`}
              sx={{
                mt: 3,
                ml: 3,
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "15%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
            >
              Cancel
            </Button>
          </form>
        </CardContent>
        <CardActions></CardActions>
      </Card>
    </Container>
  );
};
