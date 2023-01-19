export interface IOrder {
  id: number;
  totalAmount: number;
  trackingNumber: number;
  deliveryDate: Date;
  orderDate: Date;
  stationaryStoreId: number;
  invoiceid: number;
}
