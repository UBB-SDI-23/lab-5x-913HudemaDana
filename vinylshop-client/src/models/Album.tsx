import { Band } from './Band';
import { Artist } from './Artist';
import { Vinyl } from './Vinyl';

export interface Album {
  id: number;
  name?: string;
  lyrics?: string;
  realiseDate?: Date;
  band?: Band;
  bandId?: number;
  artist?: Artist;
  artistId?: number;
  vinyls?: Vinyl[];
}
