export interface UserCreate {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  userRole: number;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  age?: number;
  height?: number; // In cm
}

export interface Provider {
  specialization: string;
  hospitalAffiliation: string;
}

export interface UserDTO {
  userCreateDTO: UserCreate;
  providerDTO?: Provider; // Optional, only used for providers
}
