import { Album } from './Album';
import { Stock } from './Stock';

export interface Vinyl {
  id?: number;
  edition?: string;
  durablility?: number;
  size?: number;
  material?: string;
  groove?: string;
  speed?: string;
  condition?: string;
  album?: Album;
  albumId: number;
  stocks?: Stock[];
}
