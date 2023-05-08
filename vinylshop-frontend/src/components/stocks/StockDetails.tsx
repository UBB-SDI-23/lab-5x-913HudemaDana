import { Card, CardActions, CardContent, IconButton } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Stock } from "../../models/Stock";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import React from "react";
import axios from "axios";
import { Shop } from "../../models/Shop";

export const StockDetails = () => {
  const { stockId } = useParams();
  const [stock, setStock] = useState<Stock>();

  useEffect(() => {
    const fetchStock = async () => {
      try {
        // TODO: handle loading state
        const response = await axios.get<Stock>(
          `${BACKEND_API_URL}/stocks/${stockId}`
        );
        const stock = await response.data;
        setStock(stock);
      } catch (error) {
        console.error("Error fetching stocks details:", error);
      }
    };
    fetchStock();
  }, [stockId]);

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
          <IconButton component={Link} sx={{ mr: 3 }} to={`/stocks`}>
            <ArrowBackIcon />
          </IconButton>{" "}
          <h1>Stock Details</h1>
          <p>Stock Available Vinyls: {stock?.availableVinyls}</p>
          <p>Stock Price: {stock?.price}</p>
          <p>
            Stock Vinyl: {stock?.vinyl?.edition + " " + stock?.vinyl?.condition}
          </p>
          <p>Stock Shop: {stock?.shop?.town}</p>
        </CardContent>
        <CardActions>
          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/stocks/${stockId}/edit`}
          >
            <EditIcon />
          </IconButton>

          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/stocks/${stockId}/delete`}
          >
            <DeleteForeverIcon sx={{ color: "red" }} />
          </IconButton>
        </CardActions>
      </Card>
    </Container>
  );
};
