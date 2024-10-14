export interface UserCreate {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  userRole: number;
}

export interface Provider {
  specialization: string;
  hospitalAffiliation: string;
}

export interface UserDTO {
  userCreateDTO: UserCreate;
  providerDTO?: Provider; // Optional, only used for providers
}
