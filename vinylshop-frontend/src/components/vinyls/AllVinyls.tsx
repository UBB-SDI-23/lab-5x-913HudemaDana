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
} from "@mui/material";
import React from "react";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Vinyl } from "../../models/Vinyl";
import ReadMoreIcon from "@mui/icons-material/ReadMore";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import AddIcon from "@mui/icons-material/Add";
import { forEach } from "lodash";
import { Album } from "../../models/Album";

export const AllVinyls = () => {
  const [loading, setLoading] = useState(false);
  const [vinyls, setVinyls] = useState<Vinyl[]>([]);
  const [albums, setAlbums] = useState<Album[]>([]);

  async function fetchAlbum(): Promise<Album[]> {
    const response = await fetch(`${BACKEND_API_URL}/albums`);
    const data = await response.json();
    return data as Album[];
  }

  async function fetchVinyl(): Promise<Vinyl[]> {
    const response = await fetch(`${BACKEND_API_URL}/vinyls`);
    const data = await response.json();
    return data as Vinyl[];
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      const albumData = await fetchAlbum();
      setAlbums(albumData);

      const vinylData = await fetchVinyl();
      setVinyls(vinylData);
    };

    fetchData();
    console.log(vinyls);
    setLoading(false);
  }, []);

  return (
    <Container
      sx={{
        display: "flex",
        flexWrap: "wrap",
        paddingTop: "5em",
      }}
    >
      <h1>All vinyls</h1>

      {loading && <CircularProgress />}
      {!loading && vinyls.length === 0 && <p>No vinyls found</p>}
      {!loading && (
        <IconButton component={Link} sx={{ mr: 3 }} to={`/vinyls/add`}>
          <Tooltip title="Add a new vinyl" arrow>
            <AddIcon color="primary" />
          </Tooltip>
        </IconButton>
      )}
      {!loading && vinyls.length > 0 && (
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>#</TableCell>
                <TableCell align="center">Album Title</TableCell>
                <TableCell align="center">Edition</TableCell>
                <TableCell align="right">Durability</TableCell>
                <TableCell align="right">Size</TableCell>
                <TableCell align="right">Material</TableCell>
                <TableCell align="center">Groove</TableCell>
                <TableCell align="center">Speed</TableCell>
                <TableCell align="center">Condition</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {vinyls.map((vinyl, index) => (
                <TableRow key={vinyl.id}>
                  <TableCell component="th" scope="row">
                    {index + 1}
                  </TableCell>
                  <TableCell component="th" scope="row">
                    <Link
                      to={`/vinyls/${vinyl.id}/details`}
                      title="View vinyl details"
                    >
                      {albums.find((elem) => elem.id == vinyl.albumId)?.name}
                    </Link>
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.edition ? "-" : vinyl.edition}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.durablility ? "-" : vinyl.durablility}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.size ? "-" : vinyl.size}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.material ? "-" : vinyl.material}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.groove ? "-" : vinyl.groove}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.speed ? "-" : vinyl.speed}
                  </TableCell>
                  <TableCell align="right">
                    {!vinyl.condition ? "-" : vinyl.condition}
                  </TableCell>
                  <TableCell align="right">
                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/vinyls/${vinyl.id}/details`}
                    >
                      <Tooltip title="View vinyl details" arrow>
                        <ReadMoreIcon color="primary" />
                      </Tooltip>
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/vinyls/${vinyl.id}/edit`}
                    >
                      <EditIcon />
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/vinyls/${vinyl.id}/delete`}
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
