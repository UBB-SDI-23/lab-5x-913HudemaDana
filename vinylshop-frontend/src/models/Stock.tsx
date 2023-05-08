import { Shop } from "./Shop";
import { Vinyl } from "./Vinyl";

export interface Stock {
  id: number;
  availableVinyls?: number;
  price?: number;
  shop?: Shop;
  shopId?: number;
  vinyl?: Vinyl;
  vinylId?: number;
}
