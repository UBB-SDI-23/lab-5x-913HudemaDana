import { Stock } from './Stock';

export interface Shop {
  id: number;
  town?: string;
  address?: string;
  stocks?: Stock[];
}
