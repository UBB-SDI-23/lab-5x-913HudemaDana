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
import { Stock } from "../../models/Stock";
import axios from "axios";

export const AllStocks = () => {
  const [loading, setLoading] = useState(false);
  const [stocks, setStocks] = useState<Stock[]>([]);

  async function fetchStock(): Promise<Stock[]> {
    const response = await fetch(`${BACKEND_API_URL}/stocks`);
    const data = await response.json();
    return data as Stock[];
  }

  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      const stockData = await fetchStock();
      setStocks(stockData);
    };
    fetchData();

    console.log(stocks);
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
      <h1>All stocks</h1>

      {loading && <CircularProgress />}
      {!loading && stocks.length === 0 && <p>No stocks found</p>}
      {!loading && (
        <IconButton component={Link} sx={{ mr: 3 }} to={`/stocks/add`}>
          <Tooltip title="Add a new stock" arrow>
            <AddIcon color="primary" />
          </Tooltip>
        </IconButton>
      )}
      {!loading && stocks.length > 0 && (
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>#</TableCell>
                <TableCell align="center">Available Vinyls</TableCell>
                <TableCell align="center">Price</TableCell>
                <TableCell align="right">Vinyl Edition</TableCell>
                <TableCell align="right">Shop Town</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {stocks.map((stock, index) => (
                <TableRow key={stock.id}>
                  <TableCell component="th" scope="row">
                    {index + 1}
                  </TableCell>
                  {/* <TableCell component="th" scope="row">
                    <Link
                      to={`/vinyls/${vinyl.id}/details`}
                      title="View vinyl details"
                    >
                      {stocks.find((elem) => elem.id == vinyl.stockId)?.name}
                    </Link>
                  </TableCell> */}
                  <TableCell align="right">
                    {!stock.availableVinyls ? "-" : stock.availableVinyls}
                  </TableCell>
                  <TableCell align="right">
                    {!stock.price ? "-" : stock.price}
                  </TableCell>
                  <TableCell align="right">
                    {!stock.vinylId ? "-" : stock.vinyl?.edition}
                  </TableCell>
                  <TableCell align="right">
                    {!stock.shopId ? "-" : stock.shop?.town}
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
