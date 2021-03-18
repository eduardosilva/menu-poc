export interface SearchHistory {
  moment: Date;
  input: string;
  output: string;
}

export class SearchState {
  history: SearchHistory[] = [];
}
