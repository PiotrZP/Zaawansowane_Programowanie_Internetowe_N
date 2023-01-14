export interface IOrder {
    id?: number;
    deliveryDate: Date;
    orderDate: Date;
    totalAmmount: number;
    trackingNumber?: number;
    invoiceId: number;
}