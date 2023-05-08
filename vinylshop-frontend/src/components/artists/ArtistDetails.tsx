import { Card, CardActions, CardContent, IconButton } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Artist } from "../../models/Artist";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import React from "react";
import axios from "axios";
import { Shop } from "../../models/Shop";

export const ArtistDetails = () => {
  const { artistId } = useParams();
  const [artist, setArtist] = useState<Artist>();

  useEffect(() => {
    const fetchartist = async () => {
      try {
        // TODO: handle loading state
        const response = await axios.get<Artist>(
          `${BACKEND_API_URL}/artists/${artistId}`
        );
        const artist = await response.data;
        setArtist(artist);
      } catch (error) {
        console.error("Error fetching artists details:", error);
      }
    };
    fetchartist();
  }, [artistId]);

  return (
    <Container
      sx={{
        display: "flex",
        flexDirection: "column",
        padding: "5em",
      }}
    >
      <Card>
        <CardContent>
          <IconButton component={Link} sx={{ mr: 3 }} to={`/artists`}>
            <ArrowBackIcon />
          </IconButton>{" "}
          <h1>Artist Details</h1>
          <p>Artist First Name: {artist?.firstName}</p>
          <p>Artist Last Name: {artist?.lastName}</p>
          <p>Artist Age: {artist?.age}</p>
          <p>Artist Nationality: {artist?.nationality}</p>
          <p>Artist Active Years: {artist?.activeYears}</p>
          <p>Artist Vinyls:</p>
          <ul>
            {artist?.albums?.map((album: any) => (
              <li key={album.id}>{album.Name}</li>
            ))}
          </ul>
        </CardContent>
        <CardActions>
          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/artists/${artistId}/edit`}
          >
            <EditIcon />
          </IconButton>

          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/artists/${artistId}/delete`}
          >
            <DeleteForeverIcon sx={{ color: "red" }} />
          </IconButton>
        </CardActions>
      </Card>
    </Container>
  );
};
