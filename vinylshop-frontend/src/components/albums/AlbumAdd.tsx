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
import { Album } from "../../models/Album";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import axios from "axios";
import { debounce } from "lodash";
import { Artist } from "../../models/Artist";

export const AlbumAdd = () => {
  const navigate = useNavigate();

  const [album, setAlbum] = useState<Album>({
    id: 1,
    name: "",
    lyrics: "",
    realiseDate: new Date("2022-04-17"),
    artistId: 1,
  });

  const [artists, setArtists] = useState<Artist[]>([]);

  const fetchSuggestions = async (query: string) => {
    try {
      const response = await axios.get<Artist[]>(
        `${BACKEND_API_URL}/artists/autocomplete?query=${query}`
      );
      const data = await response.data;
      setArtists(data);
      console.log(artists);
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

  const addAlbum = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    try {
      await axios.post(`${BACKEND_API_URL}/albums/addAlbum`, album);
      navigate("/albums");
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
          <IconButton component={Link} sx={{ mr: 3, mb: 3 }} to={`/albums`}>
            <ClearRoundedIcon />
          </IconButton>{" "}
          <form onSubmit={addAlbum}>
            <TextField
              id="name"
              label="Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setAlbum({ ...album, name: event.target.value })
              }
            />
            <TextField
              id="lyrics"
              label="Lyrics"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setAlbum({ ...album, lyrics: event.target.value })
              }
            />
            <DatePicker
              id="realiseDate"
              label="Realise Date"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event: { target: { value: any } }) =>
                setAlbum({ ...album, realiseDate: event.target.value })
              }
            />
            <Autocomplete
              id="artistId"
              options={artists}
              getOptionLabel={(option) =>
                `${option.firstName} ${option.lastName}`
              }
              renderInput={(params) => (
                <TextField {...params} label="Artist" variant="outlined" />
              )}
              filterOptions={(x) => x}
              onInputChange={handleInputChange}
              onChange={(event, value) => {
                if (value) {
                  console.log(value);
                  setAlbum({ ...album, artistId: value.id });
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
              Add Album
            </Button>

            <Button
              component={Link}
              to={`/albums`}
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
