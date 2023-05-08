import {
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  CircularProgress,
  Container,
  IconButton,
  Tooltip,
  Button,
  Card,
  CardContent,
} from "@mui/material";
import React from "react";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import ReadMoreIcon from "@mui/icons-material/ReadMore";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import AddIcon from "@mui/icons-material/Add";
import { forEach } from "lodash";
import { Artist } from "../../models/Artist";
import axios from "axios";

export const AllArtists = () => {
  const [loading, setLoading] = useState(false);
  const [artists, setArtists] = useState<Artist[]>([]);

  async function fetchArtist(): Promise<Artist[]> {
    const response = await fetch(`${BACKEND_API_URL}/artists`);
    const data = await response.json();
    return data as Artist[];
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      const artistData = await fetchArtist();
      setArtists(artistData);
    };
    fetchData();

    console.log(artists);
    setLoading(false);
  }, []);

  return (
    <Container
      sx={{
        display: "flex",
        flexDirection: "column",
        paddingTop: "5em",
      }}
    >
      <h1>All artists</h1>

      {loading && <CircularProgress />}
      {!loading && artists.length === 0 && <p>No artists found</p>}
      {!loading && (
        <IconButton component={Link} sx={{ mr: 3 }} to={`/artists/add`}>
          <Tooltip title="Add a new artist" arrow>
            <AddIcon color="primary" />
          </Tooltip>
        </IconButton>
      )}
      {!loading && artists.length > 0 && (
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>#</TableCell>
                <TableCell align="center">Artist First Name</TableCell>
                <TableCell align="center">Artist Last Name</TableCell>
                <TableCell align="center">Description</TableCell>
                <TableCell align="center">Age</TableCell>
                <TableCell align="right">Nationality</TableCell>
                <TableCell align="right">Active Years</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {artists.map((artist, index) => (
                <TableRow key={artist.id}>
                  <TableCell component="th" scope="row">
                    {index + 1}
                  </TableCell>
                  {/* <TableCell component="th" scope="row">
                    <Link
                      to={`/vinyls/${vinyl.id}/details`}
                      title="View vinyl details"
                    >
                      {artists.find((elem) => elem.id == vinyl.artistId)?.name}
                    </Link>
                  </TableCell> */}
                  <TableCell align="right">
                    {!artist.firstName ? "-" : artist.firstName}
                  </TableCell>
                  <TableCell align="right">
                    {!artist.lastName ? "-" : artist.lastName}
                  </TableCell>
                  <TableCell align="right">
                    {!artist.lastName ? "-" : artist.description}
                  </TableCell>
                  <TableCell align="right">
                    {!artist.age ? "-" : artist.age}
                  </TableCell>
                  <TableCell align="right">
                    {!artist.nationality ? "-" : artist.nationality}
                  </TableCell>
                  <TableCell align="right">
                    {!artist.activeYears ? "-" : artist.activeYears}
                  </TableCell>
                  <TableCell align="right">
                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/artists/${artist.id}/details`}
                    >
                      <Tooltip title="View artist details" arrow>
                        <ReadMoreIcon color="primary" />
                      </Tooltip>
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/artists/${artist.id}/edit`}
                    >
                      <EditIcon />
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/artists/${artist.id}/delete`}
                    >
                      <DeleteForeverIcon sx={{ color: "red" }} />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}
    </Container>
  );
};
