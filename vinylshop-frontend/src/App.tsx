import * as React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AppHome } from "./components/AppHome";
import { AppMenu } from "./components/AppMenu";
import { AllVinyls } from "./components/vinyls/AllVinyls";
import { VinylDetails } from "./components/vinyls/VinylDetails";
import { VinylDelete } from "./components/vinyls/VinylDelete";
import { VinylAdd } from "./components/vinyls/VinylAdd";
import { AllAlbums } from "./components/albums/AllAlbums";
import { VinylUpdate } from "./components/vinyls/VinylUpdate";
import { AlbumDetails } from "./components/albums/AlbumDetails";
import { AlbumDelete } from "./components/albums/AlbumDelete";
import { AlbumAdd } from "./components/albums/AlbumAdd";
import { AllArtists } from "./components/artists/AllArtists";
import { ArtistDetails } from "./components/artists/ArtistDetails";
import { ArtistDelete } from "./components/artists/ArtistDelete";
import { ArtistAdd } from "./components/artists/ArtistAdd";
import { AllShops } from "./components/shops/AllShops";
import { ShopDetails } from "./components/shops/ShopDetails";
import { ShopDelete } from "./components/shops/ShopDelete";
import { ShopAdd } from "./components/shops/ShopAdd";
import { AllStocks } from "./components/stocks/AllStocks";
import { StockDetails } from "./components/stocks/StockDetails";
import { StockDelete } from "./components/stocks/StockDelete";
import { StockAdd } from "./components/stocks/StockAdd";

function App() {
  return (
    <React.Fragment>
      <AppMenu />

      <Routes>
        <Route path="/" element={<AppHome />} />
        <Route path="/vinyls" element={<AllVinyls />} />
        <Route path="/vinyls/:vinylId/details" element={<VinylDetails />} />
        <Route path="/vinyls/:vinylId/edit" element={<VinylUpdate />} />
        <Route path="/vinyls/:vinylId/delete" element={<VinylDelete />} />
        <Route path="/vinyls/add" element={<VinylAdd />} />

        <Route path="/albums" element={<AllAlbums />} />
        <Route path="/albums/:albumId/details" element={<AlbumDetails />} />
        {/* <Route path="/albums/:albumId/edit" element={<AlbumUpdate />} /> */}
        <Route path="/albums/:albumId/delete" element={<AlbumDelete />} />
        <Route path="/albums/add" element={<AlbumAdd />} />

        <Route path="/artists" element={<AllArtists />} />
        <Route path="/artists/:artistId/details" element={<ArtistDetails />} />
        {/* <Route path="/artists/:artistId/edit" element={<VinylUpdate />} /> */}
        <Route path="/artists/:artistId/delete" element={<ArtistDelete />} />
        <Route path="/artists/add" element={<ArtistAdd />} />

        <Route path="/shops" element={<AllShops />} />
        <Route path="/shops/:shopId/details" element={<ShopDetails />} />
        {/* <Route path="/shops/:shopId/edit" element={<VinylUpdate />} /> */}
        <Route path="/shops/:shopId/delete" element={<ShopDelete />} />
        <Route path="/shops/add" element={<ShopAdd />} />

        <Route path="/stocks" element={<AllStocks />} />
        <Route path="/stocks/:stockId/details" element={<StockDetails />} />
        {/* <Route path="/stocks/:stockId/edit" element={<VinylUpdate />} /> */}
        <Route path="/stocks/:stockId/delete" element={<StockDelete />} />
        <Route path="/stocks/add" element={<StockAdd />} />
      </Routes>
    </React.Fragment>
  );
}

export default App;
