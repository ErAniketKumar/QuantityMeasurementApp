import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UnitMapService {
  constructor() {}
  readonly MEASUREMENT_TYPES = ['LENGTH', 'WEIGHT', 'VOLUME', 'TEMPERATURE'];

  readonly UNITS = {
    LENGTH: ['FEET', 'INCH', 'YARDS', 'CENTIMETER'],

    WEIGHT: ['GRAM', 'KILOGRAM'],

    VOLUME: ['LITRE', 'MILLILITRE', 'GALLON'],

    TEMPERATURE: ['CELSIUS', 'FAHRENHEIT'],
  };
}
