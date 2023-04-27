import { Contract } from './Contract';
import { MusicGendre } from './enums/MusicGendre';

export interface RecordLabel {
  id: number;
  name?: string;
  description?: string;
  gendre?: MusicGendre;
  contracts?: Contract[];
}
