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
import { Shop } from "../../models/Shop";
import axios from "axios";

export const AllShops = () => {
  const [loading, setLoading] = useState(false);
  const [shops, setShops] = useState<Shop[]>([]);
  const [filterAdded, setFilterAdded] = useState(false);

  async function fetchShop(): Promise<Shop[]> {
    const response = await fetch(`${BACKEND_API_URL}/shops`);
    const data = await response.json();
    return data as Shop[];
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      const shopData = await fetchShop();
      setShops(shopData);
    };
    fetchData();

    console.log(shops);
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
      <h1>All shops</h1>

      {loading && <CircularProgress />}
      {!loading && shops.length === 0 && <p>No shops found</p>}
      {!loading && (
        <IconButton component={Link} sx={{ mr: 3 }} to={`/shops/add`}>
          <Tooltip title="Add a new shop" arrow>
            <AddIcon color="primary" />
          </Tooltip>
        </IconButton>
      )}
      {!loading && shops.length > 0 && (
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>#</TableCell>
                <TableCell align="center">Shop Town</TableCell>
                <TableCell align="center">Address</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {shops.map((shop, index) => (
                <TableRow key={shop.id}>
                  <TableCell component="th" scope="row">
                    {index + 1}
                  </TableCell>
                  {/* <TableCell component="th" scope="row">
                    <Link
                      to={`/vinyls/${vinyl.id}/details`}
                      title="View vinyl details"
                    >
                      {shops.find((elem) => elem.id == vinyl.shopId)?.name}
                    </Link>
                  </TableCell> */}
                  <TableCell align="right">
                    {!shop.town ? "-" : shop.town}
                  </TableCell>
                  <TableCell align="right">
                    {!shop.address ? "-" : shop.address}
                  </TableCell>
                  <TableCell align="right">
                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/shops/${shop.id}/details`}
                    >
                      <Tooltip title="View artist details" arrow>
                        <ReadMoreIcon color="primary" />
                      </Tooltip>
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/shops/${shop.id}/edit`}
                    >
                      <EditIcon />
                    </IconButton>

                    <IconButton
                      component={Link}
                      sx={{ mr: 3 }}
                      to={`/shops/${shop.id}/delete`}
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
