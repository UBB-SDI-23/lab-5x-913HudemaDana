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
import { Stock } from "../../models/Stock";
import ClearRoundedIcon from "@mui/icons-material/ClearRounded";
import axios from "axios";
import { debounce } from "lodash";
import { Artist } from "../../models/Artist";
import { Shop } from "../../models/Shop";
import { Vinyl } from "../../models/Vinyl";

export const StockAdd = () => {
  const navigate = useNavigate();

  const [stock, setStock] = useState<Stock>({
    id: 1,
    availableVinyls: 0,
    price: 10,
  });

  const [vinyls, setVinyls] = useState<Vinyl[]>([]);
  const [shops, setShops] = useState<Shop[]>([]);

  const fetchSuggestionsVinyl = async (query: string) => {
    try {
      const response = await axios.get<Vinyl[]>(
        `${BACKEND_API_URL}/vinyls/autocomplete?query=${query}`
      );
      const data = await response.data;
      setVinyls(data);
      console.log(vinyls);
    } catch (error) {
      console.error("Error fetching suggestions:", error);
    }
  };

  const fetchSuggestionsShop = async (query: string) => {
    try {
      const response = await axios.get<Shop[]>(
        `${BACKEND_API_URL}/shops/autocomplete?query=${query}`
      );
      const data = await response.data;
      setShops(data);
      console.log(shops);
    } catch (error) {
      console.error("Error fetching suggestions:", error);
    }
  };
  const debouncedFetchSuggestionsVinyl = useCallback(
    debounce(fetchSuggestionsVinyl, 500),
    []
  );
  const debouncedFetchSuggestionsShop = useCallback(
    debounce(fetchSuggestionsVinyl, 500),
    []
  );
  useEffect(() => {
    return () => {
      debouncedFetchSuggestionsVinyl.cancel();
      debouncedFetchSuggestionsShop.cancel();
    };
  }, [debouncedFetchSuggestionsVinyl, debouncedFetchSuggestionsShop]);

  const addStock = async (event: { preventDefault: () => void }) => {
    event.preventDefault();
    try {
      await axios.post(`${BACKEND_API_URL}/stocks/addStock`, stock);
      navigate("/stocks");
    } catch (error) {
      console.log(error);
    }
  };

  const handleInputChange = (event: any, value: any, reason: any) => {
    console.log("input", value, reason);

    if (reason === "input") {
      debouncedFetchSuggestionsVinyl(value);
      debouncedFetchSuggestionsShop(value);
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
          <IconButton component={Link} sx={{ mr: 3, mb: 3 }} to={`/stocks`}>
            <ClearRoundedIcon />
          </IconButton>{" "}
          <form onSubmit={addStock}>
            <TextField
              type="number"
              id="availableVinyls"
              label="Available Vinyls"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setStock({
                  ...stock,
                  availableVinyls: parseInt(event.target.value),
                })
              }
            />
            <TextField
              type="number"
              id="price"
              label="Price"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
              onChange={(event) =>
                setStock({ ...stock, price: parseInt(event.target.value) })
              }
            />
            <Autocomplete
              id="vinylId"
              sx={{ mb: 2 }}
              options={vinyls}
              getOptionLabel={(option) =>
                `Vinyl ${option.edition} with durability ${option.durablility}`
              }
              renderInput={(params) => (
                <TextField {...params} label="Vinyl" variant="outlined" />
              )}
              filterOptions={(x) => x}
              onInputChange={handleInputChange}
              onChange={(event, value) => {
                if (value) {
                  console.log(value);
                  setStock({ ...stock, vinylId: value.id });
                }
              }}
            />
            <Autocomplete
              id="shopId"
              sx={{ mb: 2 }}
              options={shops}
              getOptionLabel={(option) => `Town ${option.town}`}
              renderInput={(params) => (
                <TextField {...params} label="Shop" variant="outlined" />
              )}
              filterOptions={(x) => x}
              onInputChange={handleInputChange}
              onChange={(event, value) => {
                if (value) {
                  console.log(value);
                  setStock({ ...stock, shopId: value.id });
                }
              }}
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
              Add Stock
            </Button>

            <Button
              component={Link}
              to={`/stocks`}
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
