import { Card, CardActions, CardContent, IconButton } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Vinyl } from "../../models/Vinyl";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import React from "react";
import axios from "axios";
import { Shop } from "../../models/Shop";

export const VinylDetails = () => {
  const { vinylId } = useParams();
  const [vinyl, setVinyl] = useState<Vinyl>();
  const [shop, setShop] = useState<Shop[]>([]);

  useEffect(() => {
    const fetchVinyl = async () => {
      try {
        // TODO: handle loading state
        const response = await axios.get<Vinyl>(
          `${BACKEND_API_URL}/vinyls/${vinylId}`
        );
        const vinyl = await response.data;
        setVinyl(vinyl);
      } catch (error) {
        console.error("Error fetching vinyls details:", error);
      }
    };

    const fetchShops = async () => {
      try {
        const response = await axios.get<Shop[]>(`${BACKEND_API_URL}/shops`);
        const shops = await response.data;
        setShop(shops);
      } catch (error) {
        console.error("Error fetching shops for vinyl details:", error);
      }
    };
    fetchVinyl();
    fetchShops();
  }, [vinylId]);

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
          <IconButton component={Link} sx={{ mr: 3 }} to={`/vinyls`}>
            <ArrowBackIcon />
          </IconButton>{" "}
          <h1>Vinyl Details</h1>
          <p>Vinyl Album Name: {vinyl?.album?.name}</p>
          <p>Vinyl Edition: {vinyl?.edition}</p>
          <p>Vinyl Durablility: {vinyl?.durablility}</p>
          <p>Vinyl Size: {vinyl?.size}</p>
          <p>Vinyl Material: {vinyl?.material}</p>
          <p>Vinyl Groove: {vinyl?.groove}</p>
          <p>Vinyl Speed: {vinyl?.speed}</p>
          <p>Vinyl Condition: {vinyl?.condition}</p>
          <p>Vinyl Stocks:</p>
          <ul>
            {vinyl?.stocks?.map((stock: any) => (
              <li key={stock.id}>
                {stock.availableVinyls} in{" "}
                {shop.find((elem) => elem.id == stock.shopId)?.town}
              </li>
            ))}
          </ul>
        </CardContent>
        <CardActions>
          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/vinyls/${vinylId}/edit`}
          >
            <EditIcon />
          </IconButton>

          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/vinyls/${vinylId}/delete`}
          >
            <DeleteForeverIcon sx={{ color: "red" }} />
          </IconButton>
        </CardActions>
      </Card>
    </Container>
  );
};
