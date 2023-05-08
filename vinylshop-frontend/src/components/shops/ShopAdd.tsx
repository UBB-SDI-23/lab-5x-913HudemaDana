import {
  Autocomplete,
  Button,
  Card,
  CardActions,
  CardContent,
  IconButton,
  TextField,
} from "@mui/material";
import DatePicker from "@mui/lab/DatePicker";
import { Container } from "@mui/system";
import { useCallback, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Shop } from "../../models/Shop";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import axios from "axios";
import { debounce } from "lodash";
import { Artist } from "../../models/Artist";

export const ShopAdd = () => {
  const navigate = useNavigate();

  const [shop, setShop] = useState<Shop>({
    id: 1,
    town: "",
    address: "",
  });

  const addShop = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    try {
      await axios.post(`${BACKEND_API_URL}/shops/addShop`, shop);
      navigate("/shops");
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Container
      sx={{
        display: "flex",
        justifyContent: "center",
        padding: "5em",
      }}
    >
      <Card>
        <CardContent>
          <IconButton component={Link} sx={{ mr: 3, mb: 3 }} to={`/shops`}>
            <ClearRoundedIcon />
          </IconButton>{" "}
          <form onSubmit={addShop}>
            <TextField
              id="town"
              label="Town"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setShop({ ...shop, town: event.target.value })
              }
            />
            <TextField
              id="address"
              label="Address"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setShop({ ...shop, address: event.target.value })
              }
            />

            <Button
              type="submit"
              sx={{
                mt: 3,
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "15%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
            >
              Add Shop
            </Button>

            <Button
              component={Link}
              to={`/shops`}
              sx={{
                mt: 3,
                ml: 3,
                backgroundColor: "black",
                color: "#d2c4b4",
                borderRadius: "30px",
                width: "15%",
                height: "3.7em",
                "&:hover": {
                  color: "black",
                  backgroundColor: "#d2c4b4",
                },
              }}
            >
              Cancel
            </Button>
          </form>
        </CardContent>
        <CardActions></CardActions>
      </Card>
    </Container>
  );
};
