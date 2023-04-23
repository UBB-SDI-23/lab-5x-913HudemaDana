import { Artist } from './Artist';
import { Band } from './Band';
import { RecordLabel } from './RecordLabel';

export interface Contract {
  id: number;
  duration?: string;
  startDate?: Date;
  artist: Artist;
  artistId: number;
  band?: Band;
  bandId?: number;
  recordLabel: RecordLabel;
  recordLabelId?: number;
}
