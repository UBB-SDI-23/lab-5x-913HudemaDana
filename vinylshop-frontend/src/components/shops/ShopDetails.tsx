import { Card, CardActions, CardContent, IconButton } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Shop } from "../../models/Shop";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import React from "react";
import axios from "axios";

export const ShopDetails = () => {
  const { shopId } = useParams();
  const [shop, setShop] = useState<Shop>();

  useEffect(() => {
    const fetchShop = async () => {
      try {
        // TODO: handle loading state
        const response = await axios.get<Shop>(
          `${BACKEND_API_URL}/shops/${shopId}`
        );
        const shop = await response.data;
        setShop(shop);
      } catch (error) {
        console.error("Error fetching shops details:", error);
      }
    };
    fetchShop();
  }, [shopId]);

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
          <IconButton component={Link} sx={{ mr: 3 }} to={`/shops`}>
            <ArrowBackIcon />
          </IconButton>{" "}
          <h1>Shop Details</h1>
          <p>Shop Town: {shop?.town}</p>
          <p>Shop Address: {shop?.address}</p>
          <p>Shop Stocks:</p>
          <ul>
            {shop?.stocks?.map((stock: any) => (
              <li key={stock.id}>
                {stock.availableVinyls} vinyls with {stock.price}
              </li>
            ))}
          </ul>
        </CardContent>
        <CardActions>
          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/shops/${shopId}/edit`}
          >
            <EditIcon />
          </IconButton>

          <IconButton
            component={Link}
            sx={{ mr: 3 }}
            to={`/shops/${shopId}/delete`}
          >
            <DeleteForeverIcon sx={{ color: "red" }} />
          </IconButton>
        </CardActions>
      </Card>
    </Container>
  );
};
