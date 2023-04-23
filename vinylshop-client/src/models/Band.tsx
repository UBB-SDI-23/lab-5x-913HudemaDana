import { Contract } from './Contract';
import { Album } from './Album';

export interface Band {
  id: number;
  name?: string;
  description?: string;
  startDate?: Date;
  numberOfMembers?: number;
  numberOfAwards?: number;
  contracts?: Contract[];
  albums?: Album[];
}
