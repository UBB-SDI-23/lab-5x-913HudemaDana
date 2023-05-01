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
import { Album } from "../../models/Album";
import axios from "axios";

export const AllAlbums = () => {
  const [loading, setLoading] = useState(false);
  const [albums, setAlbums] = useState<Album[]>([]);
  const [filterAdded, setFilterAdded] = useState(false);

  const handleFilter = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    const response = await axios.get<Album[]>(
      `${BACKEND_API_URL}/albums/filterAlbumsByVinylSize`
    );
    const albums = await response.data;
    setAlbums(albums);
    setFilterAdded(true);
  };

  const handleCancelFilter = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    const albumData = await fetchAlbum();
    setAlbums(albumData);
    setFilterAdded(false);
  };

  async function fetchAlbum(): Promise<Album[]> {
    const response = await fetch(`${BACKEND_API_URL}/albums`);
    const data = await response.json();
    return data as Album[];
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      const albumData = await fetchAlbum();
      setAlbums(albumData);
    };
    fetchData();

    console.log(albums);
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
      <h1>All albums</h1>

      {loading && <CircularProgress />}
      {!loading && albums.length === 0 && <p>No albums found</p>}
      {!loading && albums.length > 0 && (
        <Card>
          <CardContent>
            <Button
              sx={{
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "15%",
                height: "3em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
              onClick={handleFilter}
            >
              Filter
            </Button>
            {filterAdded && (
              <Button
                sx={{
                  backgroundColor: "black",
                  color: "#d2c4b4",
                  borderRadius: "30px",
                  width: "15%",
                  height: "3em",
                  marginLeft: "1em",
                  "&:hover": {
                    color: "black",
                    backgroundColor: "#d2c4b4",
                  },
                }}
                onClick={handleCancelFilter}
              >
                Cancel Filter
              </Button>
            )}

            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell>#</TableCell>
                    <TableCell align="center">Album Title</TableCell>
                    <TableCell align="center">Lyrics</TableCell>
                    <TableCell align="right">realiseDate</TableCell>
                    <TableCell align="right">Artist Name</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {albums.map((album, index) => (
                    <TableRow key={album.id}>
                      <TableCell component="th" scope="row">
                        {index + 1}
                      </TableCell>
                      {/* <TableCell component="th" scope="row">
                    <Link
                      to={`/vinyls/${vinyl.id}/details`}
                      title="View vinyl details"
                    >
                      {albums.find((elem) => elem.id == vinyl.albumId)?.name}
                    </Link>
                  </TableCell> */}
                      <TableCell align="right">
                        {!album.name ? "-" : album.name}
                      </TableCell>
                      <TableCell align="right">
                        {!album.lyrics ? "-" : album.lyrics}
                      </TableCell>
                      <TableCell align="right">
                        {!album.realiseDate
                          ? "-"
                          : album.realiseDate.toString()}
                      </TableCell>
                      <TableCell align="right">
                        {!album.artistId ? "-" : album.artist?.firstName}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </CardContent>
        </Card>
      )}
    </Container>
  );
};
