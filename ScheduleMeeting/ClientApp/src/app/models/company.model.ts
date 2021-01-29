import { City } from "./city.model";
import { CompanyType } from "./company-type.model";
import { Country } from "./country.model";
import { User } from "./user.model";

export class Company{
  id: number;
  name: string;
  type: CompanyType;
  address: string;
  city: City;
  country: Country;
  phone: string;
  email_id: string;
  website: string;
  how_come_to_know: string;
  others: string;
  status: string;
  created: Date;
  modified: Date;
  users: User[];
}
