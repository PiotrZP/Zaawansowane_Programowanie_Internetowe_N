export interface IInvoice {
  id: number;
  totalPrice: number;
  date: Date;
  stationaryStoreId?: number;
}
