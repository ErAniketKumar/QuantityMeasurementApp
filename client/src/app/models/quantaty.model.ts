export interface compareRequest {
  value1: number;
  unit1: string;
  value2: number;
  unit2: string;
  measurementType: string;
}

export interface Quantity {
  value: number;
  unit: string;
  measurementType: string;
}

export interface arithmaticOperationRequest {
  quantity1: Quantity;
  quantity2: Quantity;
}

export interface convertRequest {
  quantity: Quantity;
  targetUnit: string;
}
