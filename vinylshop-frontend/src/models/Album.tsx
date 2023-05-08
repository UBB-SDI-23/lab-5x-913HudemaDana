import { Artist } from "./Artist";
import { Vinyl } from "./Vinyl";

export interface Album {
  id: number;
  name?: string;
  lyrics?: string;
  realiseDate?: Date;
  artist?: Artist;
  artistId?: number;
  vinyls?: Vinyl[];
}
