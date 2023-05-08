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
import { Link, useNavigate } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Vinyl } from "../../models/Vinyl";
import ReadMoreIcon from "@mui/icons-material/ReadMore";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import AddIcon from "@mui/icons-material/Add";
import { forEach } from "lodash";
import { Album } from "../../models/Album";
import CustomPagination from "../helpers/CustomPagination";

export const AllVinyls = () => {
  const [loading, setLoading] = useState(false);
  const [vinyls, setVinyls] = useState<Vinyl[]>([]);
  const [albums, setAlbums] = useState<Album[]>([]);
  const [sortDone, setSortDone] = useState(false);

  const [paginationOptions, setPaginationOptions] = useState({
    PageNumber: 1,
    PageSize: 10,
  });
  const [totalPages, setTotalPages] = useState(0);
  const [totalCount, setTotalCount] = useState(0);

  const fetchPaginatedVinyls = async () => {
    const response = await fetch(
      `${BACKEND_API_URL}/vinyls/paginated?pageNumber=${paginationOptions.PageNumber}&pageSize=${paginationOptions.PageSize}`
    )
      .then((response) => response.json())
      .then((data) => {
        setVinyls(data.results);
        setTotalPages(data.totalPages);
      })
      .catch((error) => {
        console.error("Error fetching paginated vinyls:", error);
      });
  };

  const handlePageChange = (PageNumber: any) => {
    setPaginationOptions({ ...paginationOptions, PageNumber });
  };

  const handlePageSizeChange = (PageSize: any) => {
    setPaginationOptions({ ...paginationOptions, PageSize, PageNumber: 1 });
  };

  const handleSort = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    const vinylData = vinyls;

    if (!sortDone) {
      setVinyls(
        vinylData.sort((a, b) => {
          if (a.durablility === null || a.durablility === undefined) return 1;
          if (b.durablility === null || b.durablility === undefined) return -1;
          if (a.durablility === b.durablility) return 0;
          return a.durablility < b.durablility ? -1 : 1;
        })
      );
      setSortDone(true);
    } else {
      setVinyls(vinylData);
      setSortDone(false);
    }
  };

  async function fetchAlbum(): Promise<Album[]> {
    const response = await fetch(`${BACKEND_API_URL}/albums`);
    const data = await response.json();
    return data as Album[];
  }

  async function fetchVinyl(): Promise<number> {
    const response = await fetch(`${BACKEND_API_URL}/vinyls`);
    const data = await response.json();
    return data.length;
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      //fetch all albums
      const albumData = await fetchAlbum();
      setAlbums(albumData);
      //count total number of vinyls
      const countVinyls = await fetchVinyl();
      setTotalCount(countVinyls);
      //fetch paginated vinyls
      await fetchPaginatedVinyls();
    };
    fetchData();
    console.log(vinyls);
    setLoading(false);
  }, [paginationOptions]);

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
        <Card>
          <CardContent>
            <Button
              sx={{
                marginBottom: "1em",
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
              onClick={handleSort}
            >
              {!sortDone ? `Sort By Durability` : `Cancel Sort`}
            </Button>
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
                          {
                            albums.find((elem) => elem.id == vinyl.albumId)
                              ?.name
                          }
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
            </TableContainer>{" "}
            <CustomPagination
              totalCount={totalCount}
              paginationOptions={paginationOptions}
              onPageChange={handlePageChange}
              onPageSizeChange={handlePageSizeChange}
            />
          </CardContent>
        </Card>
      )}
    </Container>
  );
};
