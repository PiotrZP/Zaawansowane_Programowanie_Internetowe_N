export interface IAddress {
  id?: number;
  city: string;
  postCode: string;
  buildingNumber: number;
  streetName: string;
  apartmentNumber?: number;
  country: string;
}
