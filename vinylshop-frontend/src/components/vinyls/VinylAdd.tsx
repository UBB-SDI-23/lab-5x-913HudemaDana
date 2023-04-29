import {
  Autocomplete,
  Button,
  Card,
  CardActions,
  CardContent,
  IconButton,
  TextField,
} from "@mui/material";
import { Container } from "@mui/system";
import { useCallback, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Vinyl } from "../../models/Vinyl";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import axios from "axios";
import { Album } from "../../models/Album";
import { debounce } from "lodash";
import React from "react";

export const VinylAdd = () => {
  const navigate = useNavigate();

  const [vinyl, setVinyl] = useState<Vinyl>({
    edition: "",
    durablility: 1,
    size: 7,
    material: "",
    groove: "",
    speed: "",
    condition: "",
    albumId: 1, // TODO: also read the teacher_id from the form (NOT from the user!)
  });

  const [albums, setAlbums] = useState<Album[]>([]);

  const fetchSuggestions = async (query: string) => {
    try {
      const response = await axios.get<Album[]>(
        `${BACKEND_API_URL}/albums/autocomplete?query=${query}`
      );
      const data = await response.data;
      setAlbums(data);
      console.log(albums);
    } catch (error) {
      console.error("Error fetching suggestions:", error);
    }
  };

  const debouncedFetchSuggestions = useCallback(
    debounce(fetchSuggestions, 500),
    []
  );

  useEffect(() => {
    return () => {
      debouncedFetchSuggestions.cancel();
    };
  }, [debouncedFetchSuggestions]);

  const addVinyl = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    try {
      await axios.post(`${BACKEND_API_URL}/vinyls/addVinyl`, vinyl);
      navigate("/vinyls");
    } catch (error) {
      console.log(error);
    }
  };

  const handleInputChange = (event: any, value: any, reason: any) => {
    console.log("input", value, reason);

    if (reason === "input") {
      debouncedFetchSuggestions(value);
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
          <IconButton component={Link} sx={{ mr: 3, mb: 3 }} to={`/vinyls`}>
            <ClearRoundedIcon />
          </IconButton>{" "}
          <form onSubmit={addVinyl}>
            <TextField
              id="edition"
              label="Edition"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, edition: event.target.value })
              }
            />
            <TextField
              type="number"
              id="durablility"
              label="Durablility"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({
                  ...vinyl,
                  durablility: parseInt(event.target.value),
                })
              }
            />
            <TextField
              type="number"
              id="size"
              label="Size"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, size: parseInt(event.target.value) })
              }
            />
            <TextField
              id="material"
              label="Material"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, material: event.target.value })
              }
            />
            <TextField
              id="groove"
              label="Groove"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, groove: event.target.value })
              }
            />
            <TextField
              id="speed"
              label="Speed"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, speed: event.target.value })
              }
            />
            <TextField
              id="condition"
              label="Condition"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setVinyl({ ...vinyl, condition: event.target.value })
              }
            />

            <Autocomplete
              id="albumId"
              options={albums}
              getOptionLabel={(option) =>
                `${option.name} - ${option.artist?.firstName} ${option.artist?.lastName}`
              }
              renderInput={(params) => (
                <TextField {...params} label="Album" variant="outlined" />
              )}
              filterOptions={(x) => x}
              onInputChange={handleInputChange}
              onChange={(event, value) => {
                if (value) {
                  console.log(value);
                  setVinyl({ ...vinyl, albumId: value.id });
                }
              }}
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
              Add Vinyl
            </Button>

            <Button
              component={Link}
              to={`/vinyls`}
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
