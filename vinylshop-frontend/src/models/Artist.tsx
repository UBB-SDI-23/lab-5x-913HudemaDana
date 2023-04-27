import { Contract } from './Contract';
import { Album } from './Album';

export interface Artist {
  id: number;
  firstName?: string;
  lastName?: string;
  age?: number;
  nationality?: string;
  activeYears?: number;
  contracts?: Contract[];
  albums?: Album[];
}
