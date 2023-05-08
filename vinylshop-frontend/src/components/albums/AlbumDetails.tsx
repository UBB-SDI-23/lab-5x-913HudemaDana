import { Card, CardActions, CardContent, IconButton } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Album } from "../../models/Album";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import React from "react";
import axios from "axios";
import { Shop } from "../../models/Shop";

export const AlbumDetails = () => {
  const { albumId } = useParams();
  const [album, setAlbum] = useState<Album>();

  useEffect(() => {
    const fetchAlbum = async () => {
      try {
        // TODO: handle loading state
        const response = await axios.get<Album>(
          `${BACKEND_API_URL}/albums/${albumId}`
        );
        const album = await response.data;
        setAlbum(album);
      } catch (error) {
        console.error("Error fetching albums details:", error);
      }
    };
    fetchAlbum();
  }, [albumId]);

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
          <IconButton component={Link} sx={{ mr: 3 }} to={`/albums`}>
            <ArrowBackIcon />
          </IconButton>{" "}
          <h1>Album Details</h1>
          <p>Album Name: {album?.name}</p>
          <p>Album Lyrics: {album?.lyrics}</p>
          <p>Album RealiseDate: {album?.realiseDate?.toDateString()}</p>
          <p>
            Album Artist:{" "}
            {album?.artist?.firstName + " " + album?.artist?.lastName}
          </p>
          <p>Album Vinyls:</p>
          <ul>
            {album?.vinyls?.map((vinyl: any) => (
              <li key={vinyl.id}>{vinyl.edition}</li>
            ))}
          </ul>
        </CardContent>
        <CardActions>
          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/albums/${albumId}/edit`}
          >
            <EditIcon />
          </IconButton>

          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/albums/${albumId}/delete`}
          >
            <DeleteForeverIcon sx={{ color: "red" }} />
          </IconButton>
        </CardActions>
      </Card>
    </Container>
  );
};
